import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { EmployeesComponent } from './employees/employees.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '../shared/shared.module';
import { AddModalComponent } from './add-modal/add-modal.component';
import { UpdateModalComponent } from './update-modal/update-modal.component';
import { NavbarComponent } from '../navbar/navbar.component';
import { FooterComponent } from '../footer/footer.component';

@NgModule({
  declarations: [
    EmployeesComponent,
    AddModalComponent,
    UpdateModalComponent,
    NavbarComponent,
    HomeComponent,
    FooterComponent


  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule,
  ]
})
export class DashboardModule { }
