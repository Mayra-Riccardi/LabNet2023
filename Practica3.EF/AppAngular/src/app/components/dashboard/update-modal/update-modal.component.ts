import { Component, OnInit, Inject } from '@angular/core';
import {FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from '../../service/employee.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA } from '@angular/material/dialog'; //Para traerme la data que pase por paramsal modal/IMPORTANTE!! injection token that can be used to access the data that was passed in to a dialog
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-modal',
  templateUrl: './update-modal.component.html',
  styleUrls: ['./update-modal.component.css'],
})
export class UpdateModalComponent implements OnInit {
  employeeForm: FormGroup;

  constructor(
    private _employeeService: EmployeeService,
    @Inject(MAT_DIALOG_DATA) public data: any, //inyecto la data en este caso ID
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<UpdateModalComponent>
  ) {
    this.employeeForm = this.formBuilder.group({
      LastName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*'),]),
      FirstName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*'),]),
      City: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*'),]),
      Country: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*'),]),
    });

    const employeeData = this.data.data
    this.employeeForm.patchValue({
      LastName: employeeData.LastName,
      FirstName: employeeData.FirstName,
      City: employeeData.City,
      Country: employeeData.Country,
    });
  }

  ngOnInit(): void {}

  onSubmit() {
    if (this.employeeForm.valid) {
      const formData = { ...this.employeeForm.value, Id: this.data.data.Id };
      // Emite los datos del formulario para que el componente principal los mneje

      Swal.fire({
        title: 'Are you sure?',
        text: "You can't undo this action!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, update',
        cancelButtonText: 'Cancel',
      }).then((result) => {
        if (result.isConfirmed) {
          this._employeeService.updateEmployee(formData).subscribe({
            next: (result) => {
              this.snackBar.open('Employee succesfully updated', 'Close', {
                duration: 2000,
                panelClass: ['mat-toolbar', 'mat-primary'],
              });
              this.dialogRef.close('updated');
            },
            error: (errorResponse) => {
              if (errorResponse.error) {
                Swal.fire('Error', errorResponse.error.error, 'error');
              } else {
                console.error(
                  'Error while updating the employee',
                  errorResponse
                );
              }
            },
          });
        }
      });
    }
  }
  closeModal() {
    this.dialogRef.close();
  }
}