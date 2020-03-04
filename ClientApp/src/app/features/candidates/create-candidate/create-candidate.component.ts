import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { BasicInfo } from '../../../shared/interfaces';
import {
  CANDIDATE_EXPERIENCES,
  CANDIDATE_SOURCES,
  CANDIDATE_STATUSES,
  EMPLOYMENT_TYPES,
  GENDERS,
  LANGUAGES
} from '../../../shared/constants';
import { CandidateInsert } from '../../../shared/interfaces/candidate-insert.interface';
import { CandidatesService } from '../../../services/candidates.service';


@Component({
  selector: 'app-create-candidate',
  templateUrl: './create-candidate.component.html',
  styleUrls: [ './create-candidate.component.scss' ],
})
export class CreateCandidateComponent implements OnInit {
  candidateExperience: BasicInfo<number>[] = CANDIDATE_EXPERIENCES;
  candidateStatuses: BasicInfo<number>[] = CANDIDATE_STATUSES;
  candidateSources: BasicInfo<number>[] = CANDIDATE_SOURCES;
  employmentTypes: BasicInfo<number>[] = EMPLOYMENT_TYPES;
  genders: BasicInfo<number>[] = GENDERS;
  languages: string[] = LANGUAGES;
  candidateSkills: string[] = [
    '.net Developer',
    'Angular developer',
    'React developer',
    'Human resources',
    'Vue developer'
  ];
  createCandidateForm: FormGroup;
  skills: string | string[] = [];
  newCandidate: CandidateInsert;

  constructor(private formBuilder: FormBuilder, private candidatesService: CandidatesService) {
  }

  ngOnInit() {
    this.createCandidateForm = this.initCreateCandidateForm();
  }

  initCreateCandidateForm(): FormGroup {
    return this.formBuilder.group({
      firstName: [ '', [ Validators.required, Validators.maxLength(64) ] ],
      lastName: [ '', [ Validators.required, Validators.maxLength(64) ] ],
      dateOfBirth: [ '', [ Validators.required ] ],
      gender: [ '', [] ],
      location: [ 'Lviv', [ Validators.maxLength(128) ] ],
      readyToRelocate: [ '', [] ],
      desiredPosition: [ '', [ Validators.maxLength(128) ] ],
      industry: [ '', [ Validators.maxLength(128) ] ],
      experience: [ '', [] ],
      currentWork: [ '', [ Validators.maxLength(128) ] ],
      currentPosition: [ '', [ Validators.maxLength(128) ] ],
      employmentType: [ '', [] ],
      education: [ '', [ Validators.maxLength(256) ] ],
      languages: [ '', [] ],
      desiredSalary: [ '', [] ],
      phoneNumber: [ '', [ Validators.maxLength(32) ] ],
      email: [ '', [ Validators.email, Validators.maxLength(128) ] ],
      skype: [ '', [ Validators.maxLength(128) ] ],
      linkedIn: [ '', [ Validators.maxLength(128) ] ],
      telegram: [ '', [ Validators.maxLength(128) ] ],
      facebook: [ '', [ Validators.maxLength(128) ] ],
      homePage: [ '', [ Validators.maxLength(256) ] ],
      status: [ '', [] ],
      source: [ '', [] ],
      skills: [ '', [ Validators.maxLength(1024) ] ],
      description: [ '', [ Validators.maxLength(2048) ] ]
    });
  }

  skillSelected(event) {
    console.log(event);
    this.skills = event;
  }

  createCandidate() {
    this.newCandidate = {
      firstName: this.createCandidateForm.get('firstName').value,
      lastName: this.createCandidateForm.get('lastName').value,
      dateOfBirth: this.createCandidateForm.get('dateOfBirth').value,
      gender: +this.createCandidateForm.get('gender').value,
      location: this.createCandidateForm.get('location').value,
      readyToRelocate: this.createCandidateForm.get('readyToRelocate').value,
      desiredPosition: this.createCandidateForm.get('desiredPosition').value,
      industry: this.createCandidateForm.get('industry').value,
      experience: +this.createCandidateForm.get('experience').value,
      currentWork: this.createCandidateForm.get('currentWork').value,
      currentPosition: this.createCandidateForm.get('currentPosition').value,
      employmentType: +this.createCandidateForm.get('employmentType').value,
      education: this.createCandidateForm.get('education').value,
      languages: this.createCandidateForm.get('languages').value.toString(),
      desiredSalary: +this.createCandidateForm.get('desiredSalary').value,
      phoneNumber: this.createCandidateForm.get('phoneNumber').value,
      email: this.createCandidateForm.get('email').value,
      skype: this.createCandidateForm.get('skype').value,
      linkedIn: this.createCandidateForm.get('linkedIn').value,
      telegram: this.createCandidateForm.get('telegram').value,
      facebook: this.createCandidateForm.get('facebook').value,
      homePage: this.createCandidateForm.get('homePage').value,
      status: +this.createCandidateForm.get('status').value,
      source: +this.createCandidateForm.get('source').value,
      skills: this.createCandidateForm.get('skills').value.toString(),
      description: this.createCandidateForm.get('description').value,
      preferableMethod: 0,
      responsibleBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69'
    };

    this.candidatesService.createCandidate(this.newCandidate).subscribe(response => {
      console.log(this.newCandidate);
      console.log(response);
    });
  }
}
