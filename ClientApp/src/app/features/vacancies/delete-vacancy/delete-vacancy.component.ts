import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { VacancyGeneralInfo } from '../../../shared/interfaces';
import { VacanciesService } from '../../../services/vacancies.service';

@Component({
  selector: 'app-delete-vacancy',
  templateUrl: './delete-vacancy.component.html',
  styleUrls: ['./delete-vacancy.component.scss']
})
export class DeleteVacancyComponent {
  errorMessage = '';

  constructor(
    private vacancyService: VacanciesService,
    private matDialogRef: MatDialogRef<DeleteVacancyComponent>,
    @Inject(MAT_DIALOG_DATA) public vacancy: VacancyGeneralInfo
  ) {
  }

  deleteVacancy() {
    this.vacancyService.deleteVacancy(this.vacancy.id).subscribe(response => {
      this.matDialogRef.close();
    }, error => {
      this.errorMessage = error.statusText;
    });
  }
}
