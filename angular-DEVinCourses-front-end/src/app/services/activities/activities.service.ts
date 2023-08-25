import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import SERVER_ACTIVITIES from 'src/app/constants/server_activities';
import { IActivitie } from 'src/app/models/activitie';

@Injectable({
  providedIn: 'root'
})
export class ActivitiesService {
  token:string | null = localStorage.getItem('token');


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    token: new HttpHeaders({ 'Autorization': 'bearer'+ this.token})
  }

  constructor(private http:HttpClient) { }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

  postActivitie(body: IActivitie){
    return this.http.post<IActivitie>(SERVER_ACTIVITIES, body, this.httpOptions)
    .pipe(
      catchError(this.handleError)
    )
  }

  putActivities(title: string, body: IActivitie){
    return this.http.put<IActivitie>(`${SERVER_ACTIVITIES}/${title}/edit/`, body, this.httpOptions)
    .pipe(
      catchError(this.handleError)
    )
  }

  deleteActivitie(title:string){
    return this.http.delete(`${SERVER_ACTIVITIES}/${title}/edit/`, this.httpOptions)
    .pipe(
      catchError(this.handleError)
    )
  }

  getAllActivities():Observable<IActivitie[]>{
    return this.http.get<IActivitie[]>(`${SERVER_ACTIVITIES}/getAll`, this.httpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    );
  }
}
