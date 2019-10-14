import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {};

  constructor() { }

  ngOnInit() {
  }

  // Register form button - accept changes
  register() {
    console.log(this.model);
  }
  
  // Register form button - abaddon changes
  cancel() {
    console.log('abbadon actrion');
  }

}
