import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { Employees } from 'src/app/cors/Models/employees_models';
import { EmployeeService } from '../../service/employee.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';//prueba
import { AddModalComponent } from '../add-modal/add-modal.component';
import { UpdateModalComponent } from '../update-modal/update-modal.component';



@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  displayedColumns: string[] = ['Id', 'LastName', 'FirstName', 'City', 'Country', "acciones"];
  employees: Array<Employees>=[]
  dataSource = new MatTableDataSource<Employees>(this.employees)

  constructor(private _employeeService : EmployeeService, 
    private router: Router,
    private dialog: MatDialog//prueba
    ) {}//para instanciar

  // insert() {
  //   const ruta = this.router.url + '/add'; // Obtener la ruta actual y agregar '/addOrUpdate'
  //   console.log('Navegando a:', ruta);
  //   this.router.navigateByUrl(ruta);
  // }

  //PRUEBA FUNCION INSERT
  insert() {
    // Abre el modal de inserción
    const dialogRef = this.dialog.open(AddModalComponent, {
      width: '500px', // Define el ancho del modal
    });
  
    dialogRef.afterClosed().subscribe((result) => {
      // Este código se ejecutará cuando se cierre el modal
      if (result === 'creado') {
        // Recargar la lista de empleados si se creó un nuevo empleado
        this.getAllEmployees();
      }
    });
  }

  //PRUEBA FUNCION UPDATE
  update(Id: number) {
    console.log('me llega el usuario con el id', Id);
    const dialogRef = this.dialog.open(UpdateModalComponent, {
      width: '500px', // Define el ancho del modal
      data: { Id }
    });
  
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result)
      if (result === 'actualizado') {
        // Recargar la lista de empleados si se actualizó un empleado
        this.getAllEmployees();
      }
    });
  }

  ngOnInit(): void {
    this.getAllEmployees();//llamamos getEmployees cuando la app recien arranca, ciclo de vida del inico
  }

  //Funcion para buscar empleado
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  //GetALL
  getAllEmployees(){
     this._employeeService.getAllEmployees().subscribe({
      next:(result)=>{
        this.dataSource.data = result;
         },
         error: (e) => {
          console.log("aca el error ", e)
         }
      });
    }


    //Funcion para editar
    deleteEmployee(Id: number) {
      // Llama al servicio para eliminar el empleado por su ID
      this._employeeService.deleteEmployee(Id).subscribe({
        next: () => {
          alert(`Empleado con ID ${Id} eliminado.`);      
          this.getAllEmployees();
        },
        error: (e) => {
          console.error(`Error al eliminar el empleado con ID ${Id}:`, e);
        }
      });
    }
    
}

