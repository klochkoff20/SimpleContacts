import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { DepartmentGeneralInfo, DepartmentInsert, PagedListResponse, VacancyInsert } from '../shared/interfaces';
import { ListResponse } from '../shared/interfaces/list-responce.interfase';

@Injectable({providedIn: 'root'})
export class DepartmentsService {
  host = environment.url + '/departments';

  constructor( private http: HttpClient) {
  }

  public createDepartment(department: DepartmentInsert) {
    return this.http.post<DepartmentInsert>(this.host, department);
  }

  public getAllDepartments() {
    return this.http.get<ListResponse<DepartmentGeneralInfo>>(this.host);
  }

  public getDepartments(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    return this.http.get<PagedListResponse<DepartmentGeneralInfo>>(this.host + `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`);
  }

  public deleteDepartment(id: string) {
    return this.http.delete(this.host + `/${id}`);
  }
}
