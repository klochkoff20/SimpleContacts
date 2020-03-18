import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Candidate, CandidateGeneralInfo } from '../../../shared/interfaces';
import { CandidatesService } from '../../../services/candidates.service';
import * as moment from 'moment';
import { CANDIDATE_EXPERIENCES, CANDIDATE_LEVELS, CANDIDATE_SOURCES, CANDIDATE_STATUSES } from '../../../shared/constants';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { DeleteCandidateComponent } from '../delete-candidate/delete-candidate.component';

@Component({
  selector: 'app-candidate-profile',
  templateUrl: './candidate-profile.component.html',
  styleUrls: [ './candidate-profile.component.scss' ]
})
export class CandidateProfileComponent implements OnInit {
  candidate: Candidate;
  candidateSkills: string[];
  experience = CANDIDATE_EXPERIENCES;
  level = CANDIDATE_LEVELS;
  sources = CANDIDATE_SOURCES;
  statuses = CANDIDATE_STATUSES;

  constructor(
    private route: ActivatedRoute,
    private candidateService: CandidatesService,
    private dialog: MatDialog,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.candidateService.getCandidate(this.route.snapshot.params.id).subscribe(response => {
      this.candidate = response.content;

      if (this.candidate.skills) {
        this.candidateSkills = this.candidate.skills.split(',');
      }
    }, error => {
      console.log(error);
    });
  }

  deleteCandidate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.data = { id: this.candidate.id, name: `${this.candidate.firstName} ${this.candidate.lastName}` };

    const dialogRef = this.dialog.open(DeleteCandidateComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.router.navigate([ '/candidates' ]);
      }
    });
  }

  formatDate(date) {
    return moment(date).format('DD/MM/YYYY');
  }

  countYears(date) {
    const difference = moment().diff(date, 'years');

    if (difference > 1) {
      return `${difference} years`;
    } else if (difference === 1) {
      return `1 year`;
    } else {
      return `Less then a year or none`;
    }
  }

  formatStringToMultiLine(str: string): string[] {
    return str.split(',');
  }

}
