import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { PagedListResponse } from '../shared/interfaces/paged-list-response.interface';
import { CandidateGeneralInfo } from '../shared/interfaces/candidate-general-info.interface';

@Injectable({providedIn: 'root'})
export class CandidatesService {
  host = environment.url + '/candidates';

  constructor(private http: HttpClient) {
  }

  public getCandidates(pageIndex: number, pageSize: number, order: string, field: number, filter: string) {
    return this.http.get<PagedListResponse<CandidateGeneralInfo>>(this.host + `/${pageIndex}/${pageSize}/${order}/${field}/${filter}`);
  }
}
