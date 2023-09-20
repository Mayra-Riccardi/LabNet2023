import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/dashboard/home/home.component';
import { EmployeesComponent } from './components/dashboard/employees/employees.component';

const routes: Routes = [
  {path: "", pathMatch: "full", redirectTo:"login"},
  {path: "login", component: LoginComponent},
  { path: 'home', component: HomeComponent },
  {path: "employees", component: EmployeesComponent },
  {
    path: "dashboard",
    loadChildren:() => import("./components/dashboard/dashboard.module").then(x =>x.DashboardModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
