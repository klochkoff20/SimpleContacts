import { Component, Inject, OnInit } from '@angular/core';
import { BasicInfo, DepartmentGeneralInfo, Vacancy, VacancyUpdate } from '../../../shared/interfaces';
import { EMPLOYMENT_TYPES, LANGUAGES, VACANCY_PRIORITIES } from '../../../shared/constants';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { VacanciesService } from '../../../services/vacancies.service';
import { DepartmentsService } from '../../../services/departments.service';

@Component({
  selector: 'app-update-vacancy',
  templateUrl: './update-vacancy.component.html',
  styleUrls: ['./update-vacancy.component.scss']
})
export class UpdateVacancyComponent implements OnInit {
  priorities: BasicInfo<number>[] = VACANCY_PRIORITIES;
  employmentTypes: BasicInfo<number>[] = EMPLOYMENT_TYPES;
  departments: DepartmentGeneralInfo[] = [];
  projects: string[] = [];

  updateVacancyForm: FormGroup;
  newVacancy: VacancyUpdate;
  project: string;
  errorMessage = '';

  constructor(
    private matDialogRef: MatDialogRef<UpdateVacancyComponent>,
    private formBuilder: FormBuilder,
    private vacancyService: VacanciesService,
    private departmentService: DepartmentsService,
    @Inject(MAT_DIALOG_DATA) private vacancy: Vacancy
  ) {
  }

  ngOnInit() {
    this.project = this.vacancy.project;

    this.departmentService.getAllDepartments().subscribe(response => {
      this.departments = response.content;

      for (const department of this.departments) {
        for (const project of department.projects) {
          this.projects.push(project.name);
        }
      }
    });

    this.updateVacancyForm = this.initUpdateVacancyForm();
  }

  initUpdateVacancyForm(): FormGroup {
    return this.formBuilder.group({
      name: [ this.vacancy.name, [ Validators.required, Validators.maxLength(128) ] ],
      department: [ this.vacancy.department.id, [ Validators.required ] ],
      project: [ this.vacancy.project, [ Validators.maxLength(128) ] ],
      priority: [ this.vacancy.priority, [  ] ],
      employmentType: [ this.vacancy.employmentType, [  ] ],
      location: [ this.vacancy.location, [ Validators.maxLength(128) ] ],
      salaryMin: [ this.vacancy.salaryMin, [ Validators.min(0) ] ],
      salaryMax: [ this.vacancy.salaryMax, [ Validators.min(0) ] ],
      targetDate: [ this.vacancy.targetDate, [  ] ],
      numberOfPositions: [ this.vacancy.numberOfPositions, [ Validators.min(0) ] ],
      requiredExperience: [ this.vacancy.requiredExperience, [ Validators.min(0) ] ],
      requirements: [ this.vacancy.requirements, [ Validators.maxLength(2048) ] ],
      description: [ this.vacancy.description, [ Validators.maxLength(2048) ] ]
    });
  }

  updateVacancy() {
    this.newVacancy = {
      name: this.updateVacancyForm.get('name').value,
      departmentId: this.updateVacancyForm.get('department').value,
      project: this.updateVacancyForm.get('project').value,
      priority: +this.updateVacancyForm.get('priority').value,
      employmentType: +this.updateVacancyForm.get('employmentType').value,
      location: this.updateVacancyForm.get('location').value,
      salaryMin: +this.updateVacancyForm.get('salaryMin').value,
      salaryMax: +this.updateVacancyForm.get('salaryMax').value,
      targetDate: this.updateVacancyForm.get('targetDate').value,
      numberOfPositions: +this.updateVacancyForm.get('numberOfPositions').value,
      requiredExperience: +this.updateVacancyForm.get('requiredExperience').value,
      requirements: this.updateVacancyForm.get('requirements').value,
      description: this.updateVacancyForm.get('description').value,
      createdBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69',
      responsibleBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69',
      updatedBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69'
    };

    if (this.updateVacancyForm.valid) {
      this.vacancyService.updateVacancy(this.vacancy.id, this.newVacancy).subscribe(response => {
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
