import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryImage, NgxGalleryOptions, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  user: User;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.data.subscribe(data => {
      this.user = data.user;
    });


    this.galleryOptions = [
      {
        width: '100%',
        height: '400px',
        thumbnailsColumns: 4,
        imagePercent: 100,
        preview: true,
        thumbnails: false,
        imageAnimation: NgxGalleryAnimation.Slide,
        previewZoomMax: 4,
        previewZoomMin : 1,
        previewRotate: true,
        previewBullets: true
      },
      // max-width 800
      {
        breakpoint: 800,
        width: '100%',
        height: '600px',
        imagePercent: 80,
        thumbnails: false,
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
  }

  getImages() {

    const imageUrls = [];

    // tslint:disable-next-line:prefer-for-of
    for (let i = 0;  i < this.user.photos.length; i++) {
      imageUrls.push({
        small: this.user.photos[i].url,
        medium: this.user.photos[i].url,
        big: this.user.photos[i].url,
        description: this.user.photos[i].description,
        url: this.user.photos[i].url,
        label: this.user.photos[i].dateAdded
      });
    }
    return imageUrls;
  }
}
