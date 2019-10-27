import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { LikesComponent } from './likes/likes.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserDetailsComponent } from './users/user-details/user-details.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard],
    children: [
      { path: 'users', component: UserListComponent },
      { path: 'users/:id', component: UserDetailsComponent },
      { path: 'likes', component: LikesComponent },
      { path: 'messages', component: MessagesComponent }
    ] },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
