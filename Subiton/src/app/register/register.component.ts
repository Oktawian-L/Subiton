import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthorizationService } from '../_services/authorization.service';
import { error } from 'util';
declare let alertify: any;

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() canceledRegister = new EventEmitter();

  model: any = {};

  // subscribe service and methods
  constructor(private authService: AuthorizationService) { }

  ngOnInit() {
  }

  // Register form button - accept changes
  register() {
    // register returns data, so needs subscribe
    this.authService.register(this.model).subscribe(() => {
      alertify.success('register success');
    }, errore => {
      alertify.error('error');
    });
    // this.canceledRegister.emit(true);
    console.log(this.model);
  }

  // Register form button - abaddon changes
  cancel() {
    // give value to parent component
    this.canceledRegister.emit(false);
    console.log('abbadon actrion');
  }

}
