import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'pro-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent {
  regexPassword: RegExp = /[^!@#$ %^&*()_+\-=\[\]{};':"\\|,.<>\/?]$/;

  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern(this.regexPassword)]),
  });

  userEmails = new FormGroup({
    ResetEmail: new FormControl('',[Validators.required,Validators.email])
  });

  constructor(private authService: AuthenticationService,private route: Router, private userService:  UserService) {}

  submitLogin() {
    if (this.form.invalid) {
      return;
    }

    let email = this.form.controls['email'].value;
    let password = this.form.controls['password'].value;

    this.authService.verifyLogin(email, password).subscribe({
      next: (token) => {
        this.authService.saveLocalStorage(token);
        this.authService.userAuthorized = true;
        this.route.navigateByUrl('home');
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  submitToken() {
    if (!this.userEmails.valid) {
      return;
    }

    let ResetEmail = this.userEmails.controls['ResetEmail'].value;

    this.userService.sendEmail(ResetEmail);

    this.userEmails.reset();
    alert('Token Enviado');

  }
}
