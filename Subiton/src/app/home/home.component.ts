import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;
  values: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  // Sterring the register form
  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  // Request to api
  getValues() {
    this.http.get('https://localhost:44363/api/Values').subscribe(response => {
      this.values = response;
    }, error => {
      console.error(error);
    });
  }

}
