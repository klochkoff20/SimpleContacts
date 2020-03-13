import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { CandidateInsert, CandidateUpdate, PagedListContent } from '../shared/interfaces';
import { environment } from '../../environments/environment';
import { CandidateGeneralInfo, ResponseResult } from '../shared/interfaces';
import { Candidate } from '../shared/interfaces/candidate.interface';


@Injectable({providedIn: 'root'})
export class CandidatesService {
  host = environment.url + '/candidates';

  constructor(private http: HttpClient) {
  }

  public getCandidates(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    const params = `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`;
    return this.http.get<ResponseResult<PagedListContent<CandidateGeneralInfo>>>(this.host + params);
  }

  public getCandidate(id: string) {
    return this.http.get<ResponseResult<Candidate>>(this.host + `/${id}`);
  }

  public createCandidate(candidate: CandidateInsert) {
    return this.http.post<CandidateInsert>(this.host, candidate);
  }

  public updateCandidate(id: string, candidate: CandidateUpdate) {
    return this.http.put(this.host + `/${id}`, candidate);
  }

  public deleteCandidate(id: string) {
    return this.http.delete(this.host + `/${id}`);
  }
}
