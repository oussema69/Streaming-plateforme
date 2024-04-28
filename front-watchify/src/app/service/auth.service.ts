import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Auth } from '../model/auth';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url="https://localhost:7178/api/Auth/";

  constructor(private http:HttpClient) { }
  login(auth:Auth): Observable<any> {
    return this.http.post<string>(this.url+"login", auth);

  }
}
