import { Component, Inject, OnInit } from '@angular/core';
import { CandidatesService } from '../../../services/candidates.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { CandidateGeneralInfo } from '../../../shared/interfaces';

@Component({
  selector: 'app-delete-candidate',
  templateUrl: './delete-candidate.component.html',
  styleUrls: ['./delete-candidate.component.scss']
})
export class DeleteCandidateComponent {
  errorMessage = '';

  constructor(
    private candidateService: CandidatesService,
    private matDialogRef: MatDialogRef<DeleteCandidateComponent>,
    @Inject(MAT_DIALOG_DATA) public candidate: CandidateGeneralInfo
  ) {
  }

  deleteCandidate() {
    this.candidateService.deleteCandidate(this.candidate.id).subscribe(response => {
      this.matDialogRef.close();
    }, error => {
      this.errorMessage = error.statusText;
    });
  }
}
