import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { VacancyGeneralInfo, PagedListResponse } from '../shared/interfaces';
import { VacancyInsert } from '../shared/interfaces/vacancy-insert.interface';

@Injectable({providedIn: 'root'})
export class VacanciesService {
  host = environment.url + '/vacancies';

  constructor(private http: HttpClient) {
  }

  public getVacancies(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    return this.http.get<PagedListResponse<VacancyGeneralInfo>>(this.host + `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`);
  }

  public createVacancy(vacancy: VacancyInsert) {
    return this.http.post<VacancyInsert>(this.host, vacancy);
  }
}
