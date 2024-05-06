import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  private url="https://localhost:7178/api/User/"

 

  getAllUsers(): Observable<any> {
    return this.http.get(this.url + "getAll")
      .pipe(
        catchError(error => {
          console.error('Erreur lors de la récupération des utilisateurs:', error);
          return throwError(error);
        })
      );
  }


  updateUser(id: number, userDto: any): Observable<any> {
    return this.http.post<any>(this.url + `update/${id}`, userDto)
      .pipe(
        catchError(error => {
          console.error('Erreur lors de la mise à jour de l\'utilisateur:', error);
          return throwError(error);
        })
      );
  }


  deactivateUser(id: number): Observable<any> {
    return this.http.post<any>(this.url + `deactivate/${id}`, {})
      .pipe(
        catchError(error => {
          console.error('Erreur lors de la désactivation de l\'utilisateur:', error);
          return throwError(error);
        })
      );
  }

}



