import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { LikesComponent } from './likes/likes.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { UserDetailResolver } from './_resolvers/user-details.resolver';
import { UserListResolver } from './_resolvers/user-list.resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard],
    children: [
      { path: 'users', component: UserListComponent, resolve: { users: UserListResolver } },
      { path: 'users/:id', component: UserDetailsComponent, resolve: {user: UserDetailResolver} },
      { path: 'profile/edit', component: UserEditComponent, resolve: { user: UserEditResolver } },
      { path: 'likes', component: LikesComponent },
      { path: 'messages', component: MessagesComponent }
    ] },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
