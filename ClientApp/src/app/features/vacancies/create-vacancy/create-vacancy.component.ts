import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

import { BasicInfo } from '../../../shared/interfaces/basic-info.interface';

@Component({
  selector: 'app-create-vacancy',
  templateUrl: './create-vacancy.component.html',
  styleUrls: [ './create-vacancy.component.scss' ]
})
export class CreateVacancyComponent implements OnInit {
  genders: BasicInfo<number>[] = [
    { id: 0, name: 'Male' },
    { id: 1, name: 'Female' }
  ];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data);
  }

  ngOnInit() {
  }

}
