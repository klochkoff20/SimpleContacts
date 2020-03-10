import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { CandidateGeneralInfo, PagedListResponse } from '../shared/interfaces';
import { CandidateInsert } from '../shared/interfaces/candidate-insert.interface';

@Injectable({providedIn: 'root'})
export class CandidatesService {
  host = environment.url + '/candidates';

  constructor(private http: HttpClient) {
  }

  public getCandidates(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    return this.http.get<PagedListResponse<CandidateGeneralInfo>>(this.host + `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`);
  }

  public createCandidate(candidate: CandidateInsert) {
    return this.http.post<CandidateInsert>(this.host, candidate);
  }

  public deleteCandidate(id: string) {
    return this.http.delete(this.host + `/${id}`);
  }
}
