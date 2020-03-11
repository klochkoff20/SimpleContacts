import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatPaginator, MatSort } from '@angular/material';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, of } from 'rxjs';

import { CreateDepartmentComponent } from './create-department/create-department.component';
import { BasicInfo, CandidateGeneralInfo, DepartmentGeneralInfo } from '../../shared/interfaces';
import { DepartmentsService } from '../../services/departments.service';
import { DEPARTMENT_STATUSES } from '../../shared/constants';
import { departmentsColumn } from '../../shared/enums';
import { DeleteDepartmentComponent } from './delete-department/delete-department.component';
import { UpdateCandidateComponent } from '../candidates/update-candidate/update-candidate.component';
import { UpdateDepartmentComponent } from './update-department/update-department.component';


@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: [ './departments.component.scss' ]
})
export class DepartmentsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    departmentsColumn[departmentsColumn.id],
    departmentsColumn[departmentsColumn.name],
    departmentsColumn[departmentsColumn.status],
    departmentsColumn[departmentsColumn.vacancies],
    departmentsColumn[departmentsColumn.projects],
    departmentsColumn[departmentsColumn.responsibleUser],
    departmentsColumn[departmentsColumn.contacts],
    departmentsColumn[departmentsColumn.actions]
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
  departmentsChange: EventEmitter<any> = new EventEmitter();

  constructor(
    private departmentsService: DepartmentsService,
    private dialog: MatDialog
  ) {
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => {
      this.paginator.pageIndex = 0;
    });

    merge(this.sort.sortChange, this.paginator.page, this.filterChange, this.departmentsChange)
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
          this.errorMessage = error.statusText;
          return of([]);
        })
      ).subscribe(data => this.data = data);
  }

  createDepartment() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;

    const dialogRef = this.dialog.open(CreateDepartmentComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(response => {
      this.departmentsChange.emit();
    });
  }

  updateDepartment(department: DepartmentGeneralInfo) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;

    this.departmentsService.getDepartment(department.id).subscribe(response => {
      dialogConfig.data = response.content;

      const dialogRef = this.dialog.open(UpdateDepartmentComponent, dialogConfig);

      dialogRef.afterClosed().subscribe(result => {
        this.departmentsChange.emit();
      });
    }, error => {
      console.log(error);
    });
  }

  deleteDepartment(department) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.data = department;

    const dialogRef = this.dialog.open(DeleteDepartmentComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(response => {
      this.departmentsChange.emit();
    });
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

  formatStringToMultiLine(str: BasicInfo<string>[]): string {
    return str.map(s => s.name).join(',\n');
  }

}
