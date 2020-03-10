import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { DepartmentsService } from '../../../services/departments.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BasicInfo, DepartmentInsert } from '../../../shared/interfaces';
import { DEPARTMENT_STATUSES, LOCATIONS } from '../../../shared/constants';

@Component({
  selector: 'app-create-department',
  templateUrl: './create-department.component.html',
  styleUrls: [ './create-department.component.scss' ]
})
export class CreateDepartmentComponent implements OnInit {
  departmentStatuses: BasicInfo<number>[] = DEPARTMENT_STATUSES;
  locations: string[] = LOCATIONS;
  createDepartmentForm: FormGroup;
  newDepartment: DepartmentInsert;
  errorMessage = '';

  constructor(
    private matDialogRef: MatDialogRef<CreateDepartmentComponent>,
    private formBuilder: FormBuilder,
    private departmentService: DepartmentsService
  ) {
  }

  ngOnInit() {
    this.createDepartmentForm = this.initCreateDepartmentForm();
  }

  initCreateDepartmentForm(): FormGroup {
    return this.formBuilder.group({
      name: [ '', [ Validators.required, Validators.pattern('^(?!\\s*$).+'), Validators.maxLength(64) ] ],
      location: [ '', [ Validators.required, Validators.pattern('^(?!\\s*$).+'), Validators.maxLength(64) ] ],
      email: [ '', [ Validators.email, Validators.maxLength(128) ] ],
      phoneNumber: [ '', [ Validators.maxLength(32) ] ],
      skype: [ '', [ Validators.maxLength(128) ] ],
      status: [ '', [  ] ],
      description: [ '', [ Validators.maxLength(2048) ] ]
    });
  }

  createDepartment() {
    this.newDepartment = {
      name: this.createDepartmentForm.get('name').value,
      location: this.createDepartmentForm.get('location').value,
      email: this.createDepartmentForm.get('email').value,
      phone: this.createDepartmentForm.get('phoneNumber').value,
      skype: this.createDepartmentForm.get('skype').value,
      status: +this.createDepartmentForm.get('status').value,
      description: this.createDepartmentForm.get('description').value,
      // TODO after login
      createdBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69',
      responsibleBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69'
    };

    if (this.createDepartmentForm.valid) {
      this.departmentService.createDepartment(this.newDepartment).subscribe(response => {
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
