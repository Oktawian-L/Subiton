import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from '../_services/authorization.service';
import { error } from 'util';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  // declaring empty model
  model: any = {};
  constructor(private authService: AuthorizationService) { }

  ngOnInit() {
  }

  login() {
    // this.authService.login(this.model)).subscribe(next => { console.log("logged"); }, errore => { console.log("logged");});
    console.log('button');
    this.authService.login(this.model).subscribe(next => {
      console.log('logged2');
    }, errore => {
        console.log('error' + errore);
    });
  }
}
