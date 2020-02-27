import { Component, OnInit } from '@angular/core';
import { VacanciesService } from '../../services/vacancies.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private vacanciesService: VacanciesService) { }

  ngOnInit() {
  }

  getVacancies() {

  }
}
