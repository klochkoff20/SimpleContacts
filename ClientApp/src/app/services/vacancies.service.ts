import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { PagedListContent, ResponseResult, VacancyGeneralInfo, VacancyInsert } from '../shared/interfaces';


@Injectable({providedIn: 'root'})
export class VacanciesService {
  host = environment.url + '/vacancies';

  constructor(private http: HttpClient) {
  }

  public getVacancies(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    const params = `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`;
    return this.http.get<ResponseResult<PagedListContent<VacancyGeneralInfo>>>(this.host + params);
  }

  public createVacancy(vacancy: VacancyInsert) {
    return this.http.post<VacancyInsert>(this.host, vacancy);
  }

  public deleteVacancy(id: string) {
    return this.http.delete(this.host + `/${id}`);
  }
}
