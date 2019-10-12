import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  baseUrl = 'http://localhost:44363/api/auth/';

constructor(private http: HttpClient) {

 }
 login(model: any){
  return this.http.post(this.baseUrl + 'login',  model);
 }
}
