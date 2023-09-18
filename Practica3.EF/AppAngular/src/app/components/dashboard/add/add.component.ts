import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from "@angular/forms";
import { EmployeeService } from '../../service/employee.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent {
  public employeeForm: FormGroup;

  constructor(private _employeeService : EmployeeService, private formBuild: FormBuilder) {
    this.employeeForm = this.formBuild.group({
      LastName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]],
      FirstName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]],
      City: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]],
      Country: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]]
    });
  }
  onSubmit() {
    if (this.employeeForm.valid) {
      // El formulario es válido, puedes enviar los datos
      const formData = this.employeeForm.value;
  
      this._employeeService.addEmployee(formData).subscribe(
        (result) => {
          alert("Empleado agregado con éxito");
          console.log("Empleado agregado ", result)
        },
        (error) => {
          alert("hubo un error")
          console.error("Error al agregar el empleado", error);
        }
      );
    }
  }
}