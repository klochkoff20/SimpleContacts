import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';

import { BasicInfo, DepartmentGeneralInfo } from '../../../shared/interfaces';
import { VacanciesService } from '../../../services/vacancies.service';
import { DepartmentsService } from '../../../services/departments.service';
import { VacancyInsert } from '../../../shared/interfaces/vacancy-insert.interface';
import { EMPLOYMENT_TYPES, LANGUAGES, VACANCY_PRIORITIES } from '../../../shared/constants';

@Component({
  selector: 'app-create-vacancy',
  templateUrl: './create-vacancy.component.html',
  styleUrls: [ './create-vacancy.component.scss' ]
})
export class CreateVacancyComponent implements OnInit {
  priorities: BasicInfo<number>[] = VACANCY_PRIORITIES;
  employmentTypes: BasicInfo<number>[] = EMPLOYMENT_TYPES;
  departments: DepartmentGeneralInfo[] = [];
  projects: string[] = [];

  createVacancyForm: FormGroup;
  newVacancy: VacancyInsert;
  errorMessage = '';

  constructor(
    private matDialogRef: MatDialogRef<CreateVacancyComponent>,
    private formBuilder: FormBuilder,
    private vacancyService: VacanciesService,
    private departmentService: DepartmentsService
  ) {
  }

  ngOnInit() {
    this.createVacancyForm = this.initCreateVacancyForm();
    this.departmentService.getAllDepartments().subscribe(response => {
      this.departments = response.content;

      for (const department of this.departments) {
        for (const project of department.projects) {
          this.projects.push(project.name);
        }
      }
    });
  }

  initCreateVacancyForm(): FormGroup {
    return this.formBuilder.group({
      name: [ '', [ Validators.required, Validators.maxLength(128) ] ],
      department: [ '', [ Validators.required ] ],
      project: [ '', [ Validators.maxLength(128) ] ],
      priority: [ 1, [  ] ],
      employmentType: [ 0, [  ] ],
      location: [ 'Lviv', [ Validators.maxLength(128) ] ],
      salaryMin: [ 0, [ Validators.min(0) ] ],
      salaryMax: [ 0, [ Validators.min(0) ] ],
      targetDate: [ null, [ Validators.required ] ],
      numberOfPositions: [ 1, [ Validators.min(0) ] ],
      requiredExperience: [ '', [ Validators.min(0) ] ],
      requirements: [ '', [ Validators.maxLength(2048) ] ],
      description: [ '', [ Validators.maxLength(2048) ] ]
    });
  }

  createVacancy() {
    this.newVacancy = {
      name: this.createVacancyForm.get('name').value,
      departmentId: this.createVacancyForm.get('department').value,
      project: this.createVacancyForm.get('project').value,
      priority: +this.createVacancyForm.get('priority').value,
      employmentType: +this.createVacancyForm.get('employmentType').value,
      location: this.createVacancyForm.get('location').value,
      salaryMin: +this.createVacancyForm.get('salaryMin').value,
      salaryMax: +this.createVacancyForm.get('salaryMax').value,
      targetDate: this.createVacancyForm.get('targetDate').value,
      numberOfPositions: +this.createVacancyForm.get('numberOfPositions').value,
      requiredExperience: +this.createVacancyForm.get('requiredExperience').value,
      requirements: this.createVacancyForm.get('requirements').value,
      description: this.createVacancyForm.get('description').value,
      createdBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69',
      responsibleBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69',
      updatedBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69',
      status: 0
    };

    if (this.createVacancyForm.valid) {
      this.vacancyService.createVacancy(this.newVacancy).subscribe(response => {
        this.matDialogRef.close();
      }, error => {
        console.log(error);
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
