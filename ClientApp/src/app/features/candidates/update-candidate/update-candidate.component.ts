import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { Candidate, BasicInfo, CandidateUpdate } from '../../../shared/interfaces';
import {
  CANDIDATE_EXPERIENCES,
  CANDIDATE_SOURCES,
  CANDIDATE_STATUSES,
  EMPLOYMENT_TYPES,
  GENDERS,
  LANGUAGES
} from '../../../shared/constants';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { CandidatesService } from '../../../services/candidates.service';

@Component({
  selector: 'app-update-candidate',
  templateUrl: './update-candidate.component.html',
  styleUrls: [ './update-candidate.component.scss' ]
})
export class UpdateCandidateComponent implements OnInit {
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
  skills: string[] = [];
  candidateLanguages: string[] = [];

  updateCandidateForm: FormGroup;
  newCandidate: CandidateUpdate;
  errorMessage = '';

  constructor(
    private matDialogRef: MatDialogRef<UpdateCandidateComponent>,
    private formBuilder: FormBuilder,
    private candidatesService: CandidatesService,
    private changeDetectorRef: ChangeDetectorRef,
    @Inject(MAT_DIALOG_DATA) public candidate: Candidate
  ) {
  }

  ngOnInit() {
    if (this.candidate.skills) {
      this.skills = this.candidate.skills.split(',');
    }

    if (this.candidate.languages) {
      this.candidateLanguages = this.candidate.languages.split(',');
    }

    this.updateCandidateForm = this.initUpdateCandidateForm();
    this.changeDetectorRef.detectChanges();
  }

  initUpdateCandidateForm(): FormGroup {
    return this.formBuilder.group({
      firstName: [ this.candidate.firstName, [ Validators.required, Validators.pattern('^(?!\\s*$).+'), Validators.maxLength(64) ] ],
      lastName: [ this.candidate.lastName, [ Validators.required, Validators.pattern('^(?!\\s*$).+'), Validators.maxLength(64) ] ],
      gender: [ this.candidate.gender, [] ],
      dateOfBirth: [ this.candidate.dateOfBirth, [] ],
      location: [ this.candidate.location, [ Validators.maxLength(128) ] ],
      readyToRelocate: [ this.candidate.readyToRelocate, [] ],
      desiredPosition: [ this.candidate.desiredPosition, [ Validators.maxLength(128) ] ],
      industry: [ this.candidate.industry, [ Validators.maxLength(128) ] ],
      experience: [ this.candidate.experience, [] ],
      currentWork: [ this.candidate.currentWork, [ Validators.maxLength(128) ] ],
      currentPosition: [ this.candidate.currentPosition, [ Validators.maxLength(128) ] ],
      employmentType: [ this.candidate.employmentType, [] ],
      education: [ this.candidate.education, [ Validators.maxLength(256) ] ],
      languages: [ this.candidateLanguages, [] ],
      desiredSalary: [ this.candidate.desiredSalary, [ Validators.min(0) ] ],
      phoneNumber: [ this.candidate.phoneNumber, [ Validators.maxLength(32) ] ],
      email: [ this.candidate.email, [ Validators.email, Validators.maxLength(128) ] ],
      skype: [ this.candidate.skype, [ Validators.maxLength(128) ] ],
      linkedIn: [ this.candidate.linkedIn, [ Validators.maxLength(128) ] ],
      telegram: [ this.candidate.telegram, [ Validators.maxLength(128) ] ],
      facebook: [ this.candidate.facebook, [ Validators.maxLength(128) ] ],
      preferableMethod: [ `${this.candidate.preferableMethod}`, [] ],
      homePage: [ this.candidate.homePage, [ Validators.maxLength(256) ] ],
      status: [ this.candidate.status, [] ],
      source: [ this.candidate.source, [] ],
      skills: [ '', [ Validators.maxLength(1024) ] ],
      skillsAsText: [ this.candidate.skillsAsText, [ Validators.maxLength(2048) ] ],
      description: [ this.candidate.description, [ Validators.maxLength(2048) ] ]
    });
  }

  updateCandidate() {
    this.newCandidate = {
      firstName: this.updateCandidateForm.get('firstName').value,
      lastName: this.updateCandidateForm.get('lastName').value,
      dateOfBirth: this.updateCandidateForm.get('dateOfBirth').value,
      gender: +this.updateCandidateForm.get('gender').value,
      location: this.updateCandidateForm.get('location').value,
      readyToRelocate: this.updateCandidateForm.get('readyToRelocate').value,
      desiredPosition: this.updateCandidateForm.get('desiredPosition').value,
      industry: this.updateCandidateForm.get('industry').value,
      experience: +this.updateCandidateForm.get('experience').value,
      currentWork: this.updateCandidateForm.get('currentWork').value,
      currentPosition: this.updateCandidateForm.get('currentPosition').value,
      employmentType: +this.updateCandidateForm.get('employmentType').value,
      education: this.updateCandidateForm.get('education').value,
      languages: this.updateCandidateForm.get('languages').value.toString(),
      desiredSalary: +this.updateCandidateForm.get('desiredSalary').value,
      phoneNumber: this.updateCandidateForm.get('phoneNumber').value,
      email: this.updateCandidateForm.get('email').value,
      skype: this.updateCandidateForm.get('skype').value,
      linkedIn: this.updateCandidateForm.get('linkedIn').value,
      telegram: this.updateCandidateForm.get('telegram').value,
      facebook: this.updateCandidateForm.get('facebook').value,
      homePage: this.updateCandidateForm.get('homePage').value,
      status: +this.updateCandidateForm.get('status').value,
      source: +this.updateCandidateForm.get('source').value,
      skills: this.updateCandidateForm.get('skills').value.toString(),
      description: this.updateCandidateForm.get('description').value,
      skillsAsText: this.updateCandidateForm.get('skillsAsText').value,
      preferableMethod: +this.updateCandidateForm.get('preferableMethod').value,
      // TODO after login
      responsibleBy: '4E08B2A6-0A10-40E2-BC0A-406D3F53FB69'
    };

    if (this.updateCandidateForm.valid) {
      this.candidatesService.updateCandidate(this.candidate.id, this.newCandidate).subscribe(response => {
        this.matDialogRef.close();
      }, error => {
        this.errorMessage = error.message;
        console.log(error);
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
