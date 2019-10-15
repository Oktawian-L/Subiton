import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  baseUrl = 'https://localhost:44363/api/AuthController/';

constructor(private http: HttpClient) {

 }

 // Authorize new session
 login(model: any) {
  return this.http.post(this.baseUrl + 'login',  model)
    .pipe(map((response: any) => {
      const user = response;
      console.error(response);
      if (user) {
        localStorage.setItem('token', user.token);
      }
    }));
 }

 // Register new user
 register(model: any) {
  return this.http.post(this.baseUrl + 'register', model);
 }
}
