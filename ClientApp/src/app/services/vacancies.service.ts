import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { environment } from '../../environments/environment';

@Injectable({providedIn: 'root'})
export class VacanciesService {
  host = environment.url + '/vacancies';

  constructor(private http: HttpClient) {
  }

  public getVacancies(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    console.log(filter);
    return this.http.get<any>(this.host + `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`);
  }
}
