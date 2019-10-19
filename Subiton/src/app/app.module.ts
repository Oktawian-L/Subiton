import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClient } from 'selenium-webdriver/http';
import { NavComponent } from './nav/nav.component';
import { AuthorizationService } from './_services/authorization.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AlertifyService } from './_services/alertify.service';
import { UserService } from './_services/user.service';
import { UserListComponent } from './users/user-list/user-list.component';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      UserListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AuthorizationService,
      AlertifyService,
      UserService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
