import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig } from '@angular/material';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, of } from 'rxjs';
import * as moment from 'moment';

import { VacanciesService } from '../../services/vacancies.service';
import { BasicInfo, VacancyGeneralInfo } from '../../shared/interfaces';
import { CreateVacancyComponent } from './create-vacancy/create-vacancy.component';
import { VACANCY_STATUSES } from '../../shared/constants';
import { vacanciesColumn } from '../../shared/enums';
import { DeleteVacancyComponent } from './delete-vacancy/delete-vacancy.component';
import { UpdateVacancyComponent } from './update-vacancy/update-vacancy.component';

@Component({
  selector: 'app-vacancies',
  templateUrl: './vacancies.component.html',
  styleUrls: [ './vacancies.component.scss', './vacancies.component.media.scss' ]
})
export class VacanciesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    vacanciesColumn[vacanciesColumn.id],
    vacanciesColumn[vacanciesColumn.name],
    vacanciesColumn[vacanciesColumn.department],
    vacanciesColumn[vacanciesColumn.project],
    vacanciesColumn[vacanciesColumn.priority],
    vacanciesColumn[vacanciesColumn.targetDate],
    vacanciesColumn[vacanciesColumn.responsibleUser],
    vacanciesColumn[vacanciesColumn.status],
    vacanciesColumn[vacanciesColumn.actions]
  ];
  statuses: BasicInfo<number>[] = VACANCY_STATUSES;

  data: VacancyGeneralInfo[] = [];
  resultsLength: number;
  isLoadingResults = true;
  isRateLimitReached = false;
  errorMessage = '';
  filter = '%20';

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  filterChange: EventEmitter<any> = new EventEmitter();
  vacanciesChanged: EventEmitter<any> = new EventEmitter();

  constructor(private vacanciesService: VacanciesService, private dialog: MatDialog) {
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => {
      this.paginator.pageIndex = 0;
    });

    merge(this.sort.sortChange, this.paginator.page, this.filterChange, this.vacanciesChanged)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.vacanciesService.getVacancies(
            this.paginator.pageIndex + 1, this.paginator.pageSize, this.sort.direction, vacanciesColumn[this.sort.active], this.filter);
        }),
        map(data => {
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = data.content.totalItems;
          return data.content.items;
        }),
        catchError(error => {
          this.isLoadingResults = false;
          this.isRateLimitReached = true;
          console.log(error.message);
          this.errorMessage = error.statusText;
          return of([]);
        })
      ).subscribe(data => this.data = data);
  }

  createVacancy() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;

    const dialogRef = this.dialog.open(CreateVacancyComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      this.vacanciesChanged.emit();
    });
  }

  updateVacancy(vacancy: VacancyGeneralInfo) {
    this.vacanciesService.getVacancy(vacancy.id).subscribe(response => {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.autoFocus = true;
      dialogConfig.data = response.content;

      const dialogRef = this.dialog.open(UpdateVacancyComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.vacanciesChanged.emit();
      });
    }, error => {
      console.log(error);
    });
  }

  updateStatus(event, vacancy) {
    this.vacanciesService.updateVacancyStatus(vacancy.id, event.value).subscribe(response => {
      this.vacanciesChanged.emit();
    }, error => {
      console.log(error);
    });
  }

  deleteVacancy(vacancy: VacancyGeneralInfo) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.data = vacancy;

    const dialogRef = this.dialog.open(DeleteVacancyComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      this.vacanciesChanged.emit();
    });
  }

  applyFilter(event: Event) {
    if ((event.target as HTMLInputElement).value.trim() !== '' && (event.target as HTMLInputElement).value !== '.') {
      this.filter = (event.target as HTMLInputElement).value;
    } else {
      this.filter = '%20';
    }
    this.paginator.pageIndex = 0;
    this.filterChange.emit(event);
  }

  formatDate(date) {
    return moment(date).format('DD/MM/YYYY');
  }

  countDays(date) {
    const difference = moment(date).diff(moment(), 'days');

    if (difference > 7) {
      return { value: 0, text: `${difference} days left` };
    } else if (difference > 0) {
      return { value: 1, text: `${difference} days left` };
    }

    return { value: 2, text: `${-difference} days passed` };
  }
}
