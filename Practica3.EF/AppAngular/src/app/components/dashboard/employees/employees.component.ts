import { Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { Employees } from 'src/app/cors/Models/employees_models';
import { EmployeeService } from '../../service/employee.service';
import { AddModalComponent } from '../add-modal/add-modal.component';
import { UpdateModalComponent } from '../update-modal/update-modal.component';


@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
})
export class EmployeesComponent implements OnInit {
  displayedColumns: string[] = [
    'LastName',
    'FirstName',
    'City',
    'Country',
    'Update/Delete',
  ];
  employees: Array<Employees> = [];
  dataSource = new MatTableDataSource<Employees>(this.employees);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  loading: boolean = true;

  constructor(
    private _employeeService: EmployeeService,
    private router: Router,
    private dialog: MatDialog
  ) {} //para instanciar

  ngOnInit(): void {
    this.getAllEmployees(); //llamamos getEmployees cuando la app recien arranca, ciclo de vida del inico
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  //Funcion para buscar empleado con filtro
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

 //FUNCION INSERT PARA MODAL
 insert() {
  const dialogRef = this.dialog.open(AddModalComponent, {
    width: '500px',
  });

  dialogRef.afterClosed().subscribe((result) => {
    if (result === 'created') {
      this.getAllEmployees();
    }
  });
}

//FUNCION UPDATE PARA MODAL
update(Id: number) {
  this._employeeService.getEmployeeById(Id).subscribe((employeeData) => {
    const dialogRef = this.dialog.open(UpdateModalComponent, {
      width: '500px',
      data: employeeData,
    });
  dialogRef.afterClosed().subscribe((result) => {
    if (result === 'updated') {
      this.getAllEmployees();
    }
  });
})
}

  //GetALL
  getAllEmployees() {
    this._employeeService.getAllEmployees().subscribe({
      next: (result) => {
        this.dataSource.data = result;
        this.loading = false;
      },
      error: (e) => {
        this.loading = false;
        console.error('Somethig wrong', e);
      },
    });
  }


  //DELETE EMPLOYEE
  deleteEmployee(Id: number) {
    Swal.fire({
      title: '¿Are you sure?',
      text: 'Yoy can´t undo this action!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete',
      cancelButtonText: 'Cancel',
    }).then((result) => {
      if (result.isConfirmed) {
        this._employeeService.deleteEmployee(Id).subscribe({
          next: () => {
            Swal.fire('Deleted!', 'The Employee was deleted', 'success');
            this.getAllEmployees();
          },
          error: (errorResponse) => {
            if (errorResponse.error) {
              Swal.fire('Error', errorResponse.error.error, 'error');
            } else {
              console.error(`Error while deleting the Employee`, errorResponse);
            }
          },
        });
      }
    });
  }
}
