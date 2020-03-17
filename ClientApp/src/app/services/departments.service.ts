import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import {
  DepartmentGeneralInfo,
  DepartmentInsert,
  PagedListContent,
  ResponseResult,
  ListResponse,
  Department, DepartmentUpdate
} from '../shared/interfaces';


@Injectable({providedIn: 'root'})
export class DepartmentsService {
  host = environment.url + '/departments';

  constructor( private http: HttpClient) {
  }

  public getAllDepartments() {
    return this.http.get<ListResponse<DepartmentGeneralInfo>>(this.host);
  }

  public getDepartments(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    const params = `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`;
    return this.http.get<ResponseResult<PagedListContent<DepartmentGeneralInfo>>>(this.host + params);
  }

  public getDepartment(id: string) {
    return this.http.get<ResponseResult<Department>>(this.host + `/${id}`);
  }

  public createDepartment(department: DepartmentInsert) {
    return this.http.post<DepartmentInsert>(this.host, department);
  }

  public updateDepartment(id: string, department: DepartmentUpdate) {
    return this.http.put(this.host + `/${id}`, department);
  }

  public updateDepartmentStatus(id: string, status: number) {
    return this.http.put(this.host + `/${id}/${status}`, status);
  }

  public deleteDepartment(id: string) {
    return this.http.delete(this.host + `/${id}`);
  }
}
