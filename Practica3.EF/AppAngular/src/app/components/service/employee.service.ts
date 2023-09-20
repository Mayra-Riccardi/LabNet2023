import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/app/environments/environment';
import { Employees } from 'src/app/cors/Models/employees_models';
import { Observable } from 'rxjs';//devuelve una promesa despues de ejecutarla

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  apiUrl : string = environment.apiLab

  constructor(private http: HttpClient) { }//ejecuta el proceso

  getAllEmployees() {
    // let url  = `${this.apiUrl}`
    return this.http.get<Employees[]>(this.apiUrl)
  }

  getEmployeeById(Id: number): Observable<Employees> {
    const url = `${this.apiUrl}/${Id}`;
    return this.http.get<Employees>(url);
  }


  addEmployee(employee: Employees): Observable<Employees> {
    return this.http.post<Employees>(this.apiUrl, employee);
  }

  updateEmployee(employee: Employees): Observable<Employees> {
    const updateUrl = `${this.apiUrl}/${employee.Id}`;
    return this.http.put<Employees>(updateUrl, employee);
  }

  deleteEmployee(Id: number): Observable<void> {
    const deleteUrl = `${this.apiUrl}/${Id}`;
    return this.http.delete<void>(deleteUrl);
  }
}
