import { Injectable } from '@angular/core';
import { Resolve, Router } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRouteSnapshot } from '@angular/router';
import { RouterStateSnapshot } from '@angular/router';p
import { Observable } from 'rxjs';

@Injectable()

export class UserDetailResolver implements Resolve<User> {


  constructor(private userService: UserService,
              private router: Router,
              private alertify: AlertifyService ) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
          : User |Observable<User> | Promise<User> {
    throw new Error('Method not implemented.');
  }

}

