import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { DepartmentGeneralInfo, PagedListResponse } from '../shared/interfaces';

@Injectable({providedIn: 'root'})
export class DepartmentsService {
  host = environment.url + '/departments';

  constructor( private http: HttpClient) {
  }

  public getDepartments(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    return this.http.get<PagedListResponse<DepartmentGeneralInfo>>(this.host + `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`);
  }
}
