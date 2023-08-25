import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import SERVER_AUTHENTICATIONS from 'src/app/constants/server_authentications';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  userAuthorized: boolean = false;

  constructor(private http: HttpClient) { }

  verifyLogin(email: string, password: string): Observable<any> {
    let headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Reponse-Type', 'Text');

    return this.http
      .post(`${SERVER_AUTHENTICATIONS}/login`, { email, password }, { responseType: 'text' })
      .pipe();
  }

  saveLocalStorage(token: string){
    localStorage.setItem('token', token);
  }
}
