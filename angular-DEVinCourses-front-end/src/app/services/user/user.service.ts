import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import SERVER_USERS from '../../constants/server_users';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  token = localStorage.getItem('token');
  headers = new HttpHeaders({'Content-Type' : 'application/json'});
  tokenHeader = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Authorization', `Bearer ${this.token}`);

  constructor(private http: HttpClient) {}

  getUser(): Observable<IUser> {
    return this.http.get<IUser>(`${SERVER_USERS}`, {headers: this.tokenHeader});
  }

  addUser(user: IUser){
   return this.http.post(SERVER_USERS, user, {headers: this.headers}).subscribe({
    next: (res) => {
      alert('Usuário criado com sucesso');
    },
    error: (err) => {
      alert(err.message);
    },
  });
  }

  editUser(user: IUser, id?: number) {
    return this.http.put<IUser>(`${SERVER_USERS}/${id}`, user, {headers: this.tokenHeader}).subscribe({
      next: (res) => {
        alert('Perfil editado com sucesso');
      },
      error: (err) => {
        alert(err.message);
      },
    });
  }

  sendEmail(email: string){
    var emailJSON = JSON.stringify(email);
    return this.http.post(`${SERVER_USERS}/reset`, emailJSON,{headers: this.headers}).subscribe();
  }

  sendToken(token: string, password:string ){
    return this.http.post(`${SERVER_USERS}/token`, {token,password},{headers: this.headers}).subscribe();
  }
}
