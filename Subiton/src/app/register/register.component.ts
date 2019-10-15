import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Input() valuesFromHome: any;
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
