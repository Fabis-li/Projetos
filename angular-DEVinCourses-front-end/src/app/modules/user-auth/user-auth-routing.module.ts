import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginGuard } from 'src/app/guards/login.guard';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegistrationComponent } from './registration/registration.component';
import { UserAuthComponent } from './user-auth.component';
import {ResetPasswordComponent}from './reset-password/reset-password.component';

const routes: Routes = [
  {
    path: '',
    component: UserAuthComponent,
    children: [
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full',
      },
      {
        path: 'login',
        component: LoginFormComponent,
      },
      {
        path: 'cadastro',
        component: RegistrationComponent,
      },
      {
        path: 'reset',
        component: ResetPasswordComponent,
      }
    ]
  },
  {
    path: 'home',
    loadChildren: () =>
      import('../main/main.module').then((m) => m.MainModule),
    canActivate:[LoginGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAuthRoutingModule { }
