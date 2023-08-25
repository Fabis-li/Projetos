import {HttpClient, HttpErrorResponse, HttpEvent, HttpHeaders, HttpResponse, } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Server } from 'http';
import { catchError, retry, tap, throwError } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import SERVER_REGISTRATIONS from 'src/app/constants/server_registrations';
import SERVER_TRAININGS from 'src/app/constants/server_trainings';
import SERVER_USERS from 'src/app/constants/server_users';
import { IRegistration } from 'src/app/models/registration';
import { ITraining } from 'src/app/models/training';
import { ItrainingDetails } from 'src/app/models/trainingDetails';
import { IUser } from 'src/app/models/user';

@Injectable({
  providedIn: 'root',
})
export class TrainingService {

  token: string | null = localStorage.getItem('token');

  totalTrainings!:number | null;
  
  headers = new HttpHeaders()
  .set('Content-Type', 'application/json')
  .set('Authorization', `Bearer ${this.token}`)

  training!: ITraining;

  constructor(private http: HttpClient) {}

  returnTraining() {
    return this.training;
  }

  //MetodoUser
  getUserByToken(token: string | null): Observable<IUser> {
    return this.http.get<IUser>(`${SERVER_USERS}`, {headers: this.headers});
  }

  //Métodos Trainings

  getAllTrainings():Observable<ITraining[]>{
    return this.http.get<ITraining[]>(`${SERVER_TRAININGS}?skip=0&take=${this.totalTrainings}`, {headers: this.headers})
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  getRecentTrainingsByUser(id: number): Observable<IRegistration[]> {
    return this.http
      .get<IRegistration[]>(
        `https://localhost:7181/api/Users/${1}/Registrations/Recents`,
        {headers: this.headers})
      }

  getByCategory(category:string):Observable<ITraining[]>{
    return this.http.get<ITraining[]>(`${SERVER_TRAININGS}?category=${category}`, {headers: this.headers})
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }


  PatchRecentTrainingsByUser(
    id: number,
    refreshDate: number
  ): Observable<number> {
    return this.http
      .patch<number>(
        `https://localhost:7181/api/Users/Registrations/${id}`,refreshDate, {headers: this.headers})
      .pipe(
        retry(2), 
        catchError(this.handleError)
      );
  }


  getTrainingsByUser(id:number| undefined):Observable<ITraining[]>{
    return this.http.get<ITraining[]>(`${SERVER_USERS}/${id}/Trainings`, {headers: this.headers})
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  getTotalRegisters():Observable<number>{
    return this.http.get<number>(`${SERVER_TRAININGS}/totalRegisters`, {headers: this.headers})
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  //metodos Registrations
  getRegistrationByUser(id:number | undefined, status:string):Observable<IRegistration[]>{
    return this.http.get<IRegistration[]>(`${SERVER_USERS}/${id}/Registrations?status=${status}`, {headers: this.headers})
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  postRegistration(registration:IRegistration){
    return this.http.post<IRegistration>(SERVER_REGISTRATIONS, registration, {headers: this.headers})
    .pipe(
      catchError(this.handleError)
    )
  }

  //metodos Modulos
  getModulesByTrainingId(id:number):Observable<any[]>{
    return this.http.get<any[]>(`${SERVER_TRAININGS}/${id}/modules`, {headers: this.headers})
    .pipe(
      retry(2),
      catchError(this.handleError)
    )

  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage =
        `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }  
  GetDetalhesTraining(id: number):Observable<ItrainingDetails>{
    return this.http.get<ItrainingDetails>(`${SERVER_TRAININGS}/${id}/usersDetails`, {headers: this.headers})
  }
}
