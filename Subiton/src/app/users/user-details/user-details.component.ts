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
    /*this.galleryImages = [
      {
        small: 'assets/lucy.png',
        medium: 'assets/lucy.png',
        big: 'assets/lucy.png'
      },
      {
        small: 'assets/lucy-1.PNG',
        medium: 'assets/lucy-1.PNG',
        big: 'assets/2lucy-1.PNG'
      },
      {
        small: 'assets/lucy-2.PNG',
        medium: 'assets/lucy-2.PNG',
        big: 'assets/lucy-2.PNG'
      }
    ];*/
  }

  getImages() {
    console.log(this.user.photos[0].Url);
    const imageUrls = [];
/*
    small | Type: string | SafeResourceUrl - url used in thumbnails
    medium | Type: string | SafeResourceUrl - url used in image
    big | Type: string | SafeResourceUrl - url used in preview
    description | Type: string - description used in preview
    url | Type: string - url used in link
    label | Type: string - label used for aria - label when thumbnail is a link
*/
      // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < 1; i++) {
        imageUrls.push({
          small: 'assets/lucy-1.PNG',
          medium: 'assets/lucy-1.PNG',
          big: 'assets/lucy-1.PNG',
          description : 'lucy',
          url: 'assets/lucy-1.PNG',
          label: 'lucy'
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
