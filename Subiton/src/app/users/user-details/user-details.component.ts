import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  user: User;

  constructor(private userServices: UserService,
              private alertify: AlertifyService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadUser();
  }

  // get user details for profile
  loadUser() {
    this.userServices.getUser(+this.route.snapshot.params['id'])
    .subscribe((userFromService: User) => {
      this.user = userFromService;
    }, error => {
      this.alertify.error(error);
    });
  }
}
