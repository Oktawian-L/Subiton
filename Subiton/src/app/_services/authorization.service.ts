import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  baseUrl = environment.apiUrl + '/AuthController/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
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
        this.decodedToken = this.jwtHelper.decodeToken(user.token);
        console.log(this.decodedToken);

      }
    }));
 }

 // Register new user
 register(model: any) {
  return this.http.post(this.baseUrl + 'register', model);
 }
 // check if user is logged in true if token exists
 loggedIn() {
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token);
 }
}
