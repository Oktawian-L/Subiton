import { Injectable } from '@angular/core';
import { Resolve, Router } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRouteSnapshot } from '@angular/router';
import { RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()

export class UserListResolver implements Resolve<User> {


  constructor(private userService: UserService,
              private router: Router,
              private alertify: AlertifyService ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.userService.getUsers().pipe(
      catchError(error => {
        this.alertify.error('Cannot get users data');
        this.router.navigate(['']);
        return of(null);
      })
    )
    ;
  }
}

