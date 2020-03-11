import { Component, Inject, OnInit } from '@angular/core';
import { BasicInfo, Department, DepartmentInsert } from '../../../shared/interfaces';
import { DEPARTMENT_STATUSES, LOCATIONS } from '../../../shared/constants';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { DepartmentsService } from '../../../services/departments.service';

@Component({
  selector: 'app-update-department',
  templateUrl: './update-department.component.html',
  styleUrls: ['./update-department.component.scss']
})
export class UpdateDepartmentComponent implements OnInit {
  departmentStatuses: BasicInfo<number>[] = DEPARTMENT_STATUSES;
  locations: string[] = LOCATIONS;
  updateDepartmentForm: FormGroup;
  newDepartment: DepartmentInsert;
  location: string;
  errorMessage = '';

  constructor(
    private matDialogRef: MatDialogRef<UpdateDepartmentComponent>,
    private formBuilder: FormBuilder,
    private departmentService: DepartmentsService,
    @Inject(MAT_DIALOG_DATA) public department: Department
  ) {
  }

  ngOnInit() {
    this.updateDepartmentForm = this.initCreateDepartmentForm();
    this.location = this.department.location;
  }

  initCreateDepartmentForm(): FormGroup {
    return this.formBuilder.group({
      name: [ this.department.name, [ Validators.required, Validators.pattern('^(?!\\s*$).+'), Validators.maxLength(64) ] ],
      location: [ this.department.location, [ Validators.required, Validators.pattern('^(?!\\s*$).+'), Validators.maxLength(64) ] ],
      email: [ this.department.email, [ Validators.email, Validators.maxLength(128) ] ],
      phoneNumber: [ this.department.phone, [ Validators.maxLength(32) ] ],
      skype: [ this.department.skype, [ Validators.maxLength(128) ] ],
      status: [ this.department.status, [  ] ],
      description: [ this.department.description, [ Validators.maxLength(2048) ] ]
    });
  }

  updateDepartment() {
    this.newDepartment = {
      name: this.updateDepartmentForm.get('name').value,
      location: this.updateDepartmentForm.get('location').value,
      email: this.updateDepartmentForm.get('email').value,
      phone: this.updateDepartmentForm.get('phoneNumber').value,
      skype: this.updateDepartmentForm.get('skype').value,
      status: +this.updateDepartmentForm.get('status').value,
      description: this.updateDepartmentForm.get('description').value,
      // TODO after login
      createdBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69',
      responsibleBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69'
    };

    if (this.updateDepartmentForm.valid) {
      this.departmentService.updateDepartment(this.department.id, this.newDepartment).subscribe(response => {
        this.matDialogRef.close();
      }, error => {
        this.errorMessage = error.message;
        this.scrollToError();
      });
    } else {
      this.errorMessage = 'Fill all the required fields!';
      this.scrollToError();
    }
  }

  scrollToError() {
    const errorField = document.querySelector('.mat-error');
    errorField.scrollIntoView({ behavior: 'smooth' });
  }
}
