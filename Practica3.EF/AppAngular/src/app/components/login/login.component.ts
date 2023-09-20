import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup} from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from "@angular/router";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',//aca le paso la plnatilla html, importante!!
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  hide:boolean=true;
  formLogin: FormGroup;


  constructor(private fb: FormBuilder, private _snackBar: MatSnackBar, private router: Router) {
  this.formLogin = this.fb.group({
    userName: ["", Validators.required],
    password: ["", Validators.required]
  })
  }

  login(){
    const userName = this.formLogin.value.userName;
    const password = this.formLogin.value.password;

    if(userName == "admin" && password == "admin"){
      this.router.navigate(["home"])
     }
     else {
      this.errorMessage()
     }

    console.log("Hola soy username ", userName);
    console.log("Hola soy password", password);
  }

  errorMessage() {
    this._snackBar.open('Usuario o contraseña inválidos', 'OK', {
      duration: 1000,
      horizontalPosition: "center",
      verticalPosition: "bottom",
    });
  }
}