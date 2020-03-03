import { Component, OnInit } from '@angular/core';

import { BasicInfo } from '../../../shared/interfaces';
import {
  CANDIDATE_EXPERIENCES,
  CANDIDATE_SOURCES,
  CANDIDATE_STATUSES,
  EMPLOYMENT_TYPES,
  GENDERS,
  LANGUAGES
} from '../../../shared/constants';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-create-candidate',
  templateUrl: './create-candidate.component.html',
  styleUrls: [ './create-candidate.component.scss' ]
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


  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.createCandidateForm = this.initCreateCandidateForm();
  }

  initCreateCandidateForm(): FormGroup {
    return this.formBuilder.group({
      firstName: [ '', [ Validators.required, Validators.maxLength(64) ] ],
      lastName: [ '', [ Validators.required, Validators.maxLength(64) ] ],
      dateOfBirth: [ '', [  ] ],
      gender: [ '', [ Validators.required ] ],
      location: [ 'Lviv', [ Validators.maxLength(128) ] ],
      readyToRelocate: [ '', [  ] ],
      desiredPosition: [ '', [ Validators.required, Validators.maxLength(128) ] ],
      industry: [ '', [ Validators.maxLength(128) ] ],
      experience: [ '', [  ] ],
      currentWork: [ '', [ Validators.maxLength(128) ] ],
      currentPosition: [ '', [ Validators.maxLength(128) ] ],
      employmentType: [ '', [  ] ],
      education: [ '', [ Validators.maxLength(256) ] ],
      languages: [ '', [  ] ],
      desiredSalary: [ '', [  ] ],
      phoneNumber: [ '', [ Validators.maxLength(32) ] ],
      email: [ '', [ Validators.email, Validators.maxLength(128) ] ],
      skype: [ '', [ Validators.maxLength(128) ] ],
      linkedIn: [ '', [ Validators.maxLength(128) ] ],
      telegram: [ '', [ Validators.maxLength(128) ] ],
      facebook: [ '', [ Validators.maxLength(128) ] ],
      homePage: [ '', [ Validators.maxLength(256) ] ],
      status: [ '', [  ] ],
      source: [ '', [  ] ],
      skills: [ '', [ Validators.maxLength(1024) ] ],
      description: [ '', [ Validators.maxLength(2048) ] ]
    });
  }

  skillSelected(event) {
    this.skills = event;
  }
}
