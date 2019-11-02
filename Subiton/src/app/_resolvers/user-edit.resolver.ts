import { Injectable } from '@angular/core';
import { Resolve, Router } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRouteSnapshot } from '@angular/router';
import { RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthorizationService } from '../_services/authorization.service';

@Injectable()

export class UserEditResolver implements Resolve<User> {


  constructor(private userService: UserService,
              private router: Router,
              private alertify: AlertifyService,
              private authService: AuthorizationService ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.userService.getUser(this.authService.decodedToken.nameid[0]).pipe(
      catchError(error => {
        console.log(this.authService.decodedToken.nameid[0]);
        this.alertify.error('Cannot get user data2');
        this.router.navigate(['/users']);
        return of(null);
      })
    )
    ;
  }
}

