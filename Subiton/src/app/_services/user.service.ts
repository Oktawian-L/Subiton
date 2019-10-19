import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl: 'https://localhost:44363/api/Users';
constructor() { }

}
