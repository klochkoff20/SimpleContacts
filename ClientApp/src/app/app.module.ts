import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HeaderComponent } from './core/header/header.component';
import { RouterModule, Routes } from '@angular/router';
import { VacanciesComponent } from './features/vacancies/vacancies.component';
import { DashboardComponent } from './core/dashboard/dashboard.component';
import { CandidatesComponent } from './features/candidates/candidates.component';
import { DepartmentsComponent } from './features/departments/departments.component';
import { ReportsComponent } from './features/reports/reports.component';
import { AccountsComponent } from './features/accounts/accounts.component';
import { OrganizerComponent } from './organizer/organizer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import {
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatSortModule
} from '@angular/material';
import { HttpClientModule } from '@angular/common/http';



const appRoutes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'organizer', component: OrganizerComponent },
  { path: 'vacancies', component: VacanciesComponent },
  { path: 'candidates', component: CandidatesComponent },
  { path: 'departments', component: DepartmentsComponent },
  { path: 'reports', component: ReportsComponent },
  { path: 'accounts', component: AccountsComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    VacanciesComponent,
    DashboardComponent,
    CandidatesComponent,
    DepartmentsComponent,
    ReportsComponent,
    AccountsComponent,
    OrganizerComponent
  ],
    imports: [
        HttpClientModule,
        BrowserModule,
        BrowserAnimationsModule,
        FontAwesomeModule,
        RouterModule.forRoot(appRoutes),
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatProgressSpinnerModule,
        MatSelectModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
