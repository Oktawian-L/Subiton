import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {

  @Input() user: User;

  constructor() { }

  ngOnInit() {
  }

  IsMale(genderNumber: any) {
    if (genderNumber === '1') {
      return true;
    } else {
      return false;
    }
  }
  getAnimalType(animaltype: any) {
    return 0;
  }
}
