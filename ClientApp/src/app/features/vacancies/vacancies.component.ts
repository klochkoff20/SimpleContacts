import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatSort, PageEvent } from '@angular/material';
import { VacanciesService } from '../../services/vacancies.service';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, Observable, observable, of } from 'rxjs';
import * as moment from 'moment';

export interface Vacancy {
  id: string;
  name: string;
  department: any;
  project: any;
  priority: string;
  targetDate: string;
  salary: string;
  responsibleUser: any;
  status: number;
}

enum columns {
  id,
  name,
  department,
  project,
  priority,
  targetDate,
  salary,
  responsibleUser,
  status
}

interface Status {
  value: number;
  name: string;
}

@Component({
  selector: 'app-vacancies',
  templateUrl: './vacancies.component.html',
  styleUrls: [ './vacancies.component.scss' ]
})
export class VacanciesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    columns[columns.id],
    columns[columns.name],
    columns[columns.department],
    columns[columns.project],
    columns[columns.priority],
    columns[columns.targetDate],
    columns[columns.salary],
    columns[columns.responsibleUser],
    columns[columns.status]
  ];
  statuses: Status[] = [
    { value: 0, name: 'New' },
    { value: 1, name: 'On Hold' },
    { value: 2, name: 'In Progress' },
    { value: 3, name: 'Payment' },
    { value: 4, name: 'Complete' },
    { value: 5, name: 'Replacement' },
    { value: 6, name: 'Canceled' }
  ];
  data: Vacancy[] = [];

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
            this.paginator.pageIndex + 1, this.paginator.pageSize, this.sort.direction, columns[this.sort.active], this.filter);
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
    if (event.target.value !== '') {
      this.filter = event.target.value;
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
