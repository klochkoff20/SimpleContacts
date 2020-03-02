import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatAutocomplete, MatAutocompleteSelectedEvent, MatChipInputEvent } from '@angular/material';

import { BasicInfo } from '../../../shared/interfaces/basic-info.interface';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
import { COMMA, ENTER, SEMICOLON } from '@angular/cdk/keycodes';

@Component({
  selector: 'app-create-candidate',
  templateUrl: './create-candidate.component.html',
  styleUrls: [ './create-candidate.component.scss' ]
})
export class CreateCandidateComponent implements OnInit {
  genders: BasicInfo<number>[] = [
    { id: 0, name: 'Male' },
    { id: 1, name: 'Female' }
  ];

  candidateExperience: BasicInfo<number>[] = [
    { id: 0, name: 'No experience' },
    { id: 1, name: 'Least 1 year' },
    { id: 2, name: '1-2 years' },
    { id: 3, name: '2-3 years' },
    { id: 4, name: '3-4 years' },
    { id: 5, name: '4-5 years' },
    { id: 6, name: 'More than 5 years' }
  ];

  candidateStatuses: BasicInfo<number>[] = [
    { id: 0, name: 'Active' },
    { id: 1, name: 'Not interested' },
    { id: 2, name: 'Passive search' },
    { id: 3, name: 'Freelancer' },
    { id: 4, name: 'Deleted' }
  ];

  candidateSources: BasicInfo<number>[] = [
    { id: 0, name: 'AddedManually' },
    { id: 1, name: 'CV' },
    { id: 2, name: 'Import from email' },
    { id: 3, name: 'JobBoard' },
    { id: 4, name: 'LinkedIn' }
  ];

  candidateSkills: string[] = [
    '.net Developer',
    'Angular developer',
    'React developer',
    'Human resources',
    'Vue developer'
  ];


  employmentTypes: BasicInfo<number>[] = [
    { id: 0, name: 'Full time' },
    { id: 1, name: 'Part time' },
    { id: 2, name: 'Remote' },
    { id: 3, name: 'Internship' },
    { id: 4, name: 'Project' },
    { id: 5, name: 'Temporary' }
  ];

  languages: string[] = [
    'Ukrainian',
    'English',
    'Russian',
    'German',
    'Polish'
  ];

  skills: string[] = [];
  filteredSkills: Observable<string[]>;
  skillCtrl = new FormControl();
  separatorKeyCodes: number[] = [ENTER, SEMICOLON, COMMA];

  @ViewChild('skillInput', { static: false }) skillInput: ElementRef<HTMLInputElement>;
  @ViewChild('skillAutocomplete', { static: false }) matAutocomplete: MatAutocomplete;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
   this.filteredSkills = this.skillCtrl.valueChanges.pipe(
     startWith(null),
     map((skill: string | null) => skill ? this._filter(skill) : this.candidateSkills.slice())
   );
  }

  ngOnInit() {
  }

  addSkill(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.skills.push(value.trim());
    }

    if (input) {
      input.value = '';
    }

    this.skillCtrl.setValue(null);
  }

  removeSkill(skill: string): void {
    const index = this.skills.indexOf(skill);

    if (index >= 0) {
      this.skills.splice(index, 1);
    }
  }

  skillSelected(event: MatAutocompleteSelectedEvent): void {
    this.skills.push(event.option.viewValue);
    this.skillInput.nativeElement.value = '';
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.candidateSkills.filter(skill => skill.toLowerCase().indexOf(filterValue) === 0);
  }
}
