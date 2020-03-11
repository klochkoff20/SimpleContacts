import { Component, Inject } from '@angular/core';
import { DepartmentsService } from '../../../services/departments.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { DepartmentGeneralInfo } from '../../../shared/interfaces';

@Component({
  selector: 'app-delete-department',
  templateUrl: './delete-department.component.html',
  styleUrls: [ './delete-department.component.scss' ]
})
export class DeleteDepartmentComponent {
  errorMessage = '';

  constructor(
    private departmentService: DepartmentsService,
    private matDialogRef: MatDialogRef<DeleteDepartmentComponent>,
    @Inject(MAT_DIALOG_DATA) public department: DepartmentGeneralInfo
  ) {
  }

  deleteDepartment() {
    this.departmentService.deleteDepartment(this.department.id).subscribe(response => {
      this.matDialogRef.close();
    }, error => {
      this.errorMessage = error.statusText;
    });
  }
}
