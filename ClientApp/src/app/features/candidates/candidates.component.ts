import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, of } from 'rxjs';
import * as moment from 'moment';

import { candidatesColumns } from '../../shared/enums/candidates.columns.enum';
import { CandidateGeneralInfo } from '../../shared/interfaces/candidate-general-info.interface';
import { CandidatesService } from '../../services/candidates.service';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.scss']
})
export class CandidatesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    candidatesColumns[candidatesColumns.id],
    candidatesColumns[candidatesColumns.name],
    candidatesColumns[candidatesColumns.position],
    candidatesColumns[candidatesColumns.responsible],
    candidatesColumns[candidatesColumns.addingDate],
    candidatesColumns[candidatesColumns.addingSource],
    candidatesColumns[candidatesColumns.lastActivity],
    candidatesColumns[candidatesColumns.actions]
  ];

  data: CandidateGeneralInfo[] = [];
  resultsLength: number;
  isLoadingResults = true;
  isRateLimitReached = false;
  errorMessage = '';
  filter = '%20';

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  filterChange: EventEmitter<any> = new EventEmitter();

  constructor(private candidatesService: CandidatesService) {
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => {
      this.paginator.pageIndex = 0;
    });

    merge(this.sort.sortChange, this.paginator.page, this.filterChange)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.candidatesService.getCandidates(
            this.paginator.pageIndex + 1, this.paginator.pageSize, this.sort.direction, candidatesColumns[this.sort.active], this.filter);
        }),
        map(data => {
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = data.content.totalItems;
          console.log(data);
          return data.content.items;
        }),
        catchError(error => {
          this.isLoadingResults = false;
          this.isRateLimitReached = true;
          console.log(error.message);
          this.errorMessage = error.message;
          return of([]);
        })
      ).subscribe(data => this.data = data);
  }

  applyFilter(event: Event) {
    if ((event.target as HTMLInputElement).value !== '') {
      this.filter = (event.target as HTMLInputElement).value;
    } else {
      this.filter = '%20';
    }
    this.paginator.pageIndex = 0;
    this.filterChange.emit(event);
  }

  formatDate(date) {
    return moment(date).format('DD/MM/YYYY');
  }
}
