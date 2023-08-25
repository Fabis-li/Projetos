import { Component, Input, OnInit } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { IUser } from 'src/app/models/user';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'pro-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent implements OnInit {
  private url = 'http://localhost:3000/Users';
  @Input() isEditingUser: boolean = false;
  User!: IUser;
  selectedFile: any;
  myImage: any;
  title = 'project';
  confirmPassword: any = true;
  formRegistration!: FormGroup;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.createFormValidation();
    if (this.isEditingUser) this.getUserForm();
  }

  createForm(User: IUser) {
    this.formRegistration = new FormGroup({
      nameInput: new FormControl(User.name),
      emailInput: new FormControl(User.email),
      ageInput: new FormControl(User.age),
      cpfInput: new FormControl(User.cpf),
      passwordInput: new FormControl(''),
      confirmInput: new FormControl(''),
    });
  }

  createFormValidation() {
    this.formRegistration = this.fb.group(
      {
        nameInput: [
          '',
          [Validators.required, Validators.minLength(3), this.checkNumbers],
        ],
        emailInput: [
          { value: '', disabled: this.isEditingUser },
          [Validators.required, Validators.email],
        ],
        ageInput: [
          '',
          [Validators.required, Validators.min(18), Validators.max(110)],
        ],
        cpfInput: [
          { value: '', disabled: this.isEditingUser },
          [Validators.required, this.checkCPF],
        ],
        passwordInput: ['', [Validators.required, Validators.minLength(8)]],
        confirmInput: ['', [Validators.required]],
      },
      {
        validators: [this.checkMatch('passwordInput', 'confirmInput')],
      }
    );
  }

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

  get f(): { [key: string]: AbstractControl } {
    return this.formRegistration.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.formRegistration.invalid) {
      return;
    }

    let formValue: IUser = {
      age: this.formRegistration.controls['ageInput'].value,
      cpf: this.formRegistration.controls['cpfInput'].value,
      email: this.formRegistration.controls['emailInput'].value,
      name: this.formRegistration.controls['nameInput'].value,
      password: this.formRegistration.controls['passwordInput'].value,
      image: this.myImage,
    };

    if (this.isEditingUser) {
      this.userService.editUser(formValue, this.User.id);
    } else {
      this.userService.addUser(formValue);
      this.router.navigateByUrl('');
    }
  }

  onReset(): void {
    this.submitted = false;
    this.formRegistration.reset();
  }

  checkNumbers(dataForm: FormControl) {
    const inputValue = dataForm.value;
    const regex = /[0-9]/;
    if (inputValue && inputValue != '') {
      return regex.test(inputValue)
        ? { checkInvalid: true, actual: inputValue }
        : null;
    }
    return null;
  }

  checkPassword(dataForm: FormControl) {
    const inputPassword = dataForm.get('passwordInput');
    const inputConfirm = dataForm.get('confirmInput');
    if (inputPassword !== inputConfirm) {
      return { checkInvalid: true, actual: inputConfirm };
    }
    return null;
  }

  checkCPF(dataForm: FormControl) {
    var Sum;
    var Remainder;
    Sum = 0;
    let stringCPF = dataForm.value;

    if (stringCPF == '00000000000')
      return { cpfInvalido: true, atual: stringCPF };

    for (let i = 1; i <= 9; i++)
      Sum = Sum + parseInt(stringCPF.substring(i - 1, i)) * (11 - i);
    Remainder = (Sum * 10) % 11;

    if (Remainder == 10 || Remainder == 11) Remainder = 0;
    if (Remainder != parseInt(stringCPF.substring(9, 10)))
      return { cpfInvalid: true, actual: stringCPF };

    Sum = 0;
    for (let i = 1; i <= 10; i++)
      Sum = Sum + parseInt(stringCPF.substring(i - 1, i)) * (12 - i);
    Remainder = (Sum * 10) % 11;

    if (Remainder == 10 || Remainder == 11) Remainder = 0;
    if (Remainder != parseInt(stringCPF.substring(10, 11)))
      return { cpfInvald: true, actual: stringCPF };
    return null;
  }

  onChange($event: any) {
    if ($event.target.files[0].size >= 10240000) {
      window.alert('tamanho não é permitido');
      $event.target.value = null;
    } else {
      const file = $event.target.files[0];
      this.convertToBase64(file);
    }
  }

  convertToBase64(file: File) {
    const imageTrasfer = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });
    imageTrasfer.subscribe((d) => {
      console.log(d);
      this.myImage = imageTrasfer;
    });
  }

  readFile(file: File, subscriber: Subscriber<any>) {
    const filereader = new FileReader();
    filereader.readAsDataURL(file);

    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    };
    filereader.onerror = (error) => {
      subscriber.error(error);
      subscriber.complete();
    };
  }

  getUserForm() {
    this.userService.getUser().subscribe((r) => {
      this.User = r;
      this.createForm(this.User);
    });
  }
}
