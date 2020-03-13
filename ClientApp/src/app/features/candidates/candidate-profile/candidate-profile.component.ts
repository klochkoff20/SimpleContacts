import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Candidate } from '../../../shared/interfaces';
import { CandidatesService } from '../../../services/candidates.service';
import * as moment from 'moment';
import { CANDIDATE_EXPERIENCES, CANDIDATE_SOURCES, CANDIDATE_STATUSES } from '../../../shared/constants';

@Component({
  selector: 'app-candidate-profile',
  templateUrl: './candidate-profile.component.html',
  styleUrls: [ './candidate-profile.component.scss' ]
})
export class CandidateProfileComponent implements OnInit {
  candidate: Candidate;
  candidateSkills: string[];
  experience = CANDIDATE_EXPERIENCES;
  sources = CANDIDATE_SOURCES;
  statuses = CANDIDATE_STATUSES;

  constructor(
    private route: ActivatedRoute,
    private candidateService: CandidatesService
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

  formatDate(date) {
    return moment(date).format('DD/MM/YYYY');
  }

  formatStringToMultiLine(str: string): string[] {
    return str.split(',');
  }

}
