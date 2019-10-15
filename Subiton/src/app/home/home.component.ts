import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  // Sterring the register form, if register form is visible or not
  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  // handling event from child component
  setRegisterMode(registerModeFromChild: boolean) {
    this.registerMode = registerModeFromChild;
  }
}
