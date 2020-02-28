import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, of } from 'rxjs';
import * as moment from 'moment';

import { VacanciesService } from '../../services/vacancies.service';
import { vacanciesColumn } from '../../shared/enums/vacancies-column.enum';
import { VacancyGeneralInfo } from '../../shared/interfaces/vacancy-general-info.interface';
import { BasicInfo } from '../../shared/interfaces/basic-info.interface';

@Component({
  selector: 'app-vacancies',
  templateUrl: './vacancies.component.html',
  styleUrls: [ './vacancies.component.scss' ]
})
export class VacanciesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    vacanciesColumn[vacanciesColumn.id],
    vacanciesColumn[vacanciesColumn.name],
    vacanciesColumn[vacanciesColumn.department],
    vacanciesColumn[vacanciesColumn.project],
    vacanciesColumn[vacanciesColumn.priority],
    vacanciesColumn[vacanciesColumn.targetDate],
    vacanciesColumn[vacanciesColumn.salary],
    vacanciesColumn[vacanciesColumn.responsibleUser],
    vacanciesColumn[vacanciesColumn.status]
  ];
  statuses: BasicInfo<number>[] = [
    { id: 0, name: 'New' },
    { id: 1, name: 'On Hold' },
    { id: 2, name: 'In Progress' },
    { id: 3, name: 'Payment' },
    { id: 4, name: 'Complete' },
    { id: 5, name: 'Replacement' },
    { id: 6, name: 'Canceled' }
  ];

  data: VacancyGeneralInfo[] = [];
  resultsLength: number;
  isLoadingResults = true;
  isRateLimitReached = false;
  errorMessage = '';
  filter = '%20';

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  filterChange: EventEmitter<any> = new EventEmitter();

  constructor(private vacanciesService: VacanciesService) {
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => {
      this.paginator.pageIndex = 0;
    });

    merge(this.sort.sortChange, this.paginator.page, this.filterChange)
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
          this.errorMessage = error.message;
          return of([]);
        })
      ).subscribe(data => this.data = data);
  }

  applyFilter(event: Event) {
    if ((event.target as HTMLInputElement).value !== '') {
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
}
