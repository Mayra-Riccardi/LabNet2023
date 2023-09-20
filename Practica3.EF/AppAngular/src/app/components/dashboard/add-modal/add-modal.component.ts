import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EmployeeService } from '../../service/employee.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-add-modal',
  templateUrl: './add-modal.component.html',
  styleUrls: ['./add-modal.component.css']
})
export class AddModalComponent implements OnInit {
  public employeeForm: FormGroup;

    @Output() employeeAdded = new EventEmitter<any>();

  constructor(
    private _employeeService : EmployeeService,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<AddModalComponent>
  ) {
    this.employeeForm = this.formBuilder.group({
      LastName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*')]),
      FirstName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*')]),
      City: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*')]),
      Country: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(10), Validators.pattern('[a-zA-Z ]*')])
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const formData = this.employeeForm.value;
  
      Swal.fire({
        title: 'Are you sure?',
        text: 'Do you want to add this employee?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, add',
        cancelButtonText: 'Cancel',
      }).then((result) => {
        if (result.isConfirmed) {
          this._employeeService.addEmployee(formData).subscribe({
            next: (result) => {
              this.snackBar.open("Employee succesfully added", "Close", {
                duration: 2000, 
                panelClass: ['mat-toolbar', 'mat-primary']
              });
              this.dialogRef.close('created');
            },
            error: (errorResponse) => {
              if (errorResponse.error) {
                Swal.fire('Error', errorResponse.error.error, 'error');
              } else {
                Swal.fire('Error', 'An error occurred while adding the employee', 'error');
                console.error('Error while adding the employee', errorResponse);
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
