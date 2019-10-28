import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { User } from '../_models/user';

@Injectable()

export class UserDetailResolver implements Resolve<User> {

}

