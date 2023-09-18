import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, FormBuilder,  Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from '../../service/employee.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';//Para traerme la data que pase por paramsal modal, sino me lo tomaba null

@Component({
  selector: 'app-update-modal',
  templateUrl: './update-modal.component.html',
  styleUrls: ['./update-modal.component.css']
})
export class UpdateModalComponent implements OnInit {
  employeeForm: FormGroup;

  constructor(
    private _employeeService : EmployeeService,
    @Inject(MAT_DIALOG_DATA) public data: any,//inyecto la data en este caso ID
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<UpdateModalComponent>,
    
    
    ) {
    this.employeeForm = this.formBuilder.group({
      LastName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.pattern('[a-zA-Z ]*')]),
      FirstName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.pattern('[a-zA-Z ]*')]),
      City: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.pattern('[a-zA-Z ]*')]),
      Country: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.pattern('[a-zA-Z ]*')])
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const formData = { ...this.employeeForm.value, Id: this.data.Id };
      console.log(formData)
      // Emite los datos del formulario para que el componente principal los maneje
      this._employeeService.updateEmployee(formData).subscribe({
        next: (result) => {
          this.snackBar.open("Empleado actualizado con éxito", "Cerrar", {
            duration: 2000, 
            panelClass: ['mat-toolbar', 'mat-primary']
          });
          console.log("Empleado actualizado ", result);
          this.dialogRef.close('actualizado');
        },
        error: (error) => {
          alert("Hubo un error al actualizar el empleado");
          console.error("Error al actualizar el empleado", error);
        }
      });
    }
  }

  closeModal() {
    // Cierra el modal sin hacer nada
    this.dialogRef.close();
  }
}
