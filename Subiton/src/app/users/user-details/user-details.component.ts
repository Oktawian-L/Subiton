import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryOptions, NgxGalleryImage } from 'ngx-gallery';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  user: User;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private userServices: UserService,
              private alertify: AlertifyService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.data.subscribe(data => {
      this.user = data.user;
    });


    this.galleryOptions = [
      {
        width: '600px',
        height: '400px',
        thumbnailsColumns: 4,
        imagePercent: 100,
        preview: true,
        imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
        breakpoint: 800,
        width: '100%',
        height: '600px',
        imagePercent: 80,
        thumbnailsPercent: 20,
        thumbnailsMargin: 20,
        thumbnailMargin: 20
      },
      // max-width 400
      {
        breakpoint: 400,
        preview: false
      }
    ];
    this.galleryImages = this.getImages();
    this.galleryImages = [
      {
        small: 'assets/lucy.png',
        medium: 'assets/lucy.png',
        big: 'assets/lucy.png'
      },
      {
        small: 'assets/lucy-1.png',
        medium: 'assets/lucy-1.png',
        big: 'assets/2lucy-1.png'
      },
      {
        small: 'assets/lucy-2.png',
        medium: 'assets/lucy-2.png',
        big: 'assets/lucy-2.png'
      }
    ];
  }

  getImages() {
      const imageUrls = [];

      // tslint:disable-next-line:prefer-for-of
      for (let i = 0; i < this.user.photos.length; i++) {
        imageUrls.push({
          small: this.user.photos[i].Url,
          medium: this.user.photos[i].Url,
          big: this.user.photos[i].Url,
          description: this.user.photos[i].Description
        });
      }
      return imageUrls;
  }

  // get user details for profile
  loadUser() {
    this.userServices.getUser(+this.route.snapshot.params.id)
    .subscribe((userFromService: User) => {
      this.user = userFromService;
    }, error => {
      this.alertify.error(error);
    });
  }
}
