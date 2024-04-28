import { HttpClient, HttpClientJsonpModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url="https://localhost:7178/api/User";

  constructor(private http:HttpClient) { }
  getUserById(id:number): Observable<User> {
    return this.http.get<User>(this.url+id);
  }
  getUserByusername(username:string): Observable<User> {
    return this.http.get<User>(this.url+"/user/"+username);
  }
}
