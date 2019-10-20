import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from '../_services/authorization.service';
import { error } from 'util';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
declare let alertify: any;

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  // declaring empty model
  model: any = {};
  constructor(public authService: AuthorizationService,
              private alertifyService: AlertifyService,
              private router: Router) { }

  ngOnInit() {
  }

  /// Method check ifuser is logged in
  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertifyService.success('Success. Welcome user.');
    }, errore => {
        this.alertifyService.error('Cannot authorize you.');
    }, () => {
      this.router.navigate(['/users']);
    });
  }

  /// Method check ifuser is logged in
  logout() {
    localStorage.removeItem('token');
    this.alertifyService.message('You are logged out.');
    this.router.navigate(['/home']);
  }

  /// Method check ifuser is logged in
  isLoggedIn() {
    // get item for local objects storage
    const token = localStorage.getItem('token');
    return  !!token;
  }

  // check if user is logged in
  loggedIn() {
    return this.authService.loggedIn();
  }
}
