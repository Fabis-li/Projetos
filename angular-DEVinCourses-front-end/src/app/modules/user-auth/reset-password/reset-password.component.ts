import { Component,OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators, AbstractControl,ValidatorFn } from '@angular/forms';
import { Router,ActivatedRoute,Routes } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { UserService } from 'src/app/services/user/user.service';



@Component({
  selector: 'pro-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  name:string ="";
  tex:string="";

  regexPassword: RegExp = /[^!@#$ %^&*()_+\-=\[\]{};':"\\|,.<>\/?]$/;

  form = new FormGroup({
    token: new FormControl(''),
    password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern(this.regexPassword)]),
    confirm: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern(this.regexPassword)]),

  },
    {
      validators: [this.checkMatch('password', 'confirm')]
    }

  );

  userEmails = new FormGroup({
    ResetEmail: new FormControl('',[Validators.required,Validators.email])
  });

  constructor(private authService: AuthenticationService,private route: Router, private userService:  UserService, private authenticationService: AuthenticationService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private routes: ActivatedRoute) {}

  submitLogin() {
    if (this.form.invalid) {
      return;
    }

    let email = this.form.controls['email'].value;
    let password = this.form.controls['password'].value;

    this.authService.verifyLogin(email, password).subscribe({
      next: (token) => {
        localStorage.setItem('token', token);
        this.authService.userAuthorized = true;
        this.route.navigateByUrl('home');
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  submitToken() {
    if (this.userEmails.valid) {
      return;
    }
  
    let token = this.tex+"=="
    let password = this.form.controls['password'].value;
    console.log(token)

    this.userService.sendToken(token,password);

    this.form.reset();
    alert('Senha Resetada');
    this.route.navigateByUrl('home');
  }

  // Função de verificação de igualdade senha X confirmação de senha
  checkMatch(controlName: string, checkControlName: string): ValidatorFn {
    return (controls: AbstractControl) => {
      const control = controls.get(controlName);
      const checkControl = controls.get(checkControlName);
      if (checkControl?.errors && !checkControl.errors['matching']) {
        return null;
      }

      if (control?.value !== checkControl?.value) {
        controls.get(checkControlName)?.setErrors({ matching: true });
        return { matching: true };
      } else {
        return null;
      }
    };
  }
  // Função de verificação de igualdade senha X confirmação de senha
  ngOnInit() {

     this.activatedRoute.params.subscribe(params => {
      const teste = Object.values(params);
      const te= JSON.stringify(teste)
		  var er = /[^a-z0-9]/gi;
		  this.tex = te.replace(er, "");

     });
  }

}
