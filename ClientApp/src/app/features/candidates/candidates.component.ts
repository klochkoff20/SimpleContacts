import { AfterViewInit, Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatPaginator, MatSort } from '@angular/material';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, of } from 'rxjs';
import * as moment from 'moment';

import { candidatesColumn } from '../../shared/enums';
import { CandidatesService } from '../../services/candidates.service';
import { CreateCandidateComponent } from './create-candidate/create-candidate.component';
import { BasicInfo, CandidateGeneralInfo } from '../../shared/interfaces';
import { DeleteCandidateComponent } from './delete-candidate/delete-candidate.component';
import { UpdateCandidateComponent } from './update-candidate/update-candidate.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: [ './candidates.component.scss' ]
})
export class CandidatesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    candidatesColumn[candidatesColumn.id],
    candidatesColumn[candidatesColumn.name],
    candidatesColumn[candidatesColumn.position],
    candidatesColumn[candidatesColumn.skills],
    candidatesColumn[candidatesColumn.responsibleUser],
    candidatesColumn[candidatesColumn.addingDate],
    candidatesColumn[candidatesColumn.addingSource],
    candidatesColumn[candidatesColumn.lastActivity],
    candidatesColumn[candidatesColumn.actions]
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
  candidatesChange: EventEmitter<any> = new EventEmitter();

  constructor(
    private candidatesService: CandidatesService,
    private dialog: MatDialog,
    private router: Router
  ) {
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => {
      this.paginator.pageIndex = 0;
    });

    merge(this.sort.sortChange, this.paginator.page, this.filterChange, this.candidatesChange)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.candidatesService.getCandidates(
            this.paginator.pageIndex + 1, this.paginator.pageSize, this.sort.direction, candidatesColumn[this.sort.active], this.filter);
        }),
        map(data => {
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = data.content.totalItems;
          return data.content.items;
        }),
        catchError(error => {
          this.isLoadingResults = false;
          this.isRateLimitReached = true;
          console.log(error.message);
          this.errorMessage = error.statusText;
          return of([]);
        })
      ).subscribe(data => this.data = data);
  }

  openProfile(candidate: CandidateGeneralInfo) {
    this.router.navigate([`candidate/${candidate.id}`]);
  }

  createCandidate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;

    const dialogRef = this.dialog.open(CreateCandidateComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      this.candidatesChange.emit();
    });
  }

  deleteCandidate(candidate: CandidateGeneralInfo) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.data = candidate;

    const dialogRef = this.dialog.open(DeleteCandidateComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      this.candidatesChange.emit();
    });
  }

  updateCandidate(candidate: CandidateGeneralInfo) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;

    this.candidatesService.getCandidate(candidate.id).subscribe(response => {
      dialogConfig.data = response.content;

      const dialogRef = this.dialog.open(UpdateCandidateComponent, dialogConfig);

      dialogRef.afterClosed().subscribe(result => {
        this.candidatesChange.emit();
      });
    }, error => {
      console.log(error);
    });
  }


  applyFilter(event: Event) {
    if ((event.target as HTMLInputElement).value !== '' && (event.target as HTMLInputElement).value !== '.') {
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


  formatStringToMultiLine(str: string[]): string {
    return str.join(',\n');
  }
}
