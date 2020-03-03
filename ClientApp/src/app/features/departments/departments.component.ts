import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, of } from 'rxjs';
import * as moment from 'moment';

import { DepartmentsService } from '../../services/departments.service';
import { BasicInfo, DepartmentGeneralInfo } from '../../shared/interfaces';
import { DEPARTMENT_STATUSES } from '../../shared/constants';
import { departmentsColumn } from '../../shared/enums';


@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.scss']
})
export class DepartmentsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    departmentsColumn[departmentsColumn.id],
    departmentsColumn[departmentsColumn.name],
    departmentsColumn[departmentsColumn.status],
    departmentsColumn[departmentsColumn.vacancies],
    departmentsColumn[departmentsColumn.projects],
    departmentsColumn[departmentsColumn.responsibleUser],
    departmentsColumn[departmentsColumn.contacts]
  ];
  statuses: BasicInfo<number>[] = DEPARTMENT_STATUSES;

  data: DepartmentGeneralInfo[] = [];
  resultsLength: number;
  isLoadingResults = true;
  isRateLimitReached = false;
  errorMessage = '';
  filter = '%20';

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  filterChange: EventEmitter<any> = new EventEmitter();

  constructor(private departmentsService: DepartmentsService) {
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
          return this.departmentsService.getDepartments(
            this.paginator.pageIndex + 1, this.paginator.pageSize, this.sort.direction, departmentsColumn[this.sort.active], this.filter);
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
    if ((event.target as HTMLInputElement).value !== '' && (event.target as HTMLInputElement).value !== '.') {
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
