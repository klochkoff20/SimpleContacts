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
import { OrganizerComponent } from './features/organizer/organizer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatCheckboxModule, MatChipsModule, MatDatepickerModule,
  MatDialogModule,
  MatFormFieldModule, MatIconModule,
  MatInputModule, MatNativeDateModule,
  MatPaginatorModule,
  MatProgressSpinnerModule, MatRadioModule,
  MatSelectModule,
  MatSortModule
} from '@angular/material';
import { HttpClientModule } from '@angular/common/http';
import { CreateVacancyComponent } from './features/vacancies/create-vacancy/create-vacancy.component';
import { CreateCandidateComponent } from './features/candidates/create-candidate/create-candidate.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomChipListComponent } from './shared/components/custom-chip-list/custom-chip-list.component';
import { CustomAutocompleteComponent } from './shared/components/custom-autocomplete/custom-autocomplete.component';
import { CreateDepartmentComponent } from './features/departments/create-department/create-department.component';
import { DeleteCandidateComponent } from './features/candidates/delete-candidate/delete-candidate.component';
import { DeleteDepartmentComponent } from './features/departments/delete-department/delete-department.component';
import { DeleteVacancyComponent } from './features/vacancies/delete-vacancy/delete-vacancy.component';
import { UpdateCandidateComponent } from './features/candidates/update-candidate/update-candidate.component';
import { UpdateDepartmentComponent } from './features/departments/update-department/update-department.component';



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
    OrganizerComponent,
    CreateVacancyComponent,
    CreateCandidateComponent,
    CustomChipListComponent,
    CustomAutocompleteComponent,
    CreateDepartmentComponent,
    DeleteCandidateComponent,
    DeleteDepartmentComponent,
    DeleteVacancyComponent,
    UpdateCandidateComponent,
    UpdateDepartmentComponent
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
    MatSelectModule,
    MatCheckboxModule,
    MatDialogModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatAutocompleteModule,
    MatRadioModule,
    MatChipsModule,
    MatIconModule,
    ReactiveFormsModule
  ],
  entryComponents: [
    CreateVacancyComponent,
    CreateCandidateComponent,
    CreateDepartmentComponent,
    UpdateCandidateComponent,
    UpdateDepartmentComponent,
    DeleteVacancyComponent,
    DeleteCandidateComponent,
    DeleteDepartmentComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
