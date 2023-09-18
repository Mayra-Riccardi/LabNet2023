import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EmployeeService } from '../../service/employee.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-add-modal',
  templateUrl: './add-modal.component.html',
  styleUrls: ['./add-modal.component.css']
})
export class AddModalComponent implements OnInit {
  public employeeForm: FormGroup;

    // Declaración del evento de salida
    @Output() employeeAdded = new EventEmitter<any>();

  constructor(
    private _employeeService : EmployeeService,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<AddModalComponent>
  ) {
    this.employeeForm = this.formBuilder.group({
      LastName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]],
      FirstName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]],
      City: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]],
      Country: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(3), Validators.pattern(/^[A-Za-z]+$/)]]
    });
  }

  ngOnInit(): void {
  }


  onSubmit() {
    if (this.employeeForm.valid) {
      const formData = this.employeeForm.value;
  
      this._employeeService.addEmployee(formData).subscribe({
        next: (result) => {
          this.snackBar.open("Empleado agregado con éxito", "Cerrar", {
            duration: 2000, 
            panelClass: ['mat-toolbar', 'mat-primary']
          });
          console.log("Empleado agregado ", result);
          this.dialogRef.close('creado');
        },
        error: (error) => {
          alert("Hubo un error al agregar el empleado");
          console.error("Error al agregar el empleado", error);
        }
      });
    }
  }
  
  //Para cerrar el modal sin hacer nada y sin necesidad de apretar cancel
  closeModal() {
    this.dialogRef.close();
  }
}
