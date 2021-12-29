import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { EditUserProfileComponent } from './edit-user-profile/edit-user-profile.component';
import { RouterModule, Routes } from '@angular/router';
import { UserGuardGuard } from '../UserLogin/user-login/user-guard.guard';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes:Routes=[
  {path:'',redirectTo:'/User/MyProfile',pathMatch:'full'},
  {path:'MyProfile',component:UserProfileComponent,canActivate:[UserGuardGuard]},
  {path:'Editprofile',component:EditUserProfileComponent,canActivate:[UserGuardGuard]}
];

@NgModule({
  declarations: [
    UserProfileComponent,
    EditUserProfileComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    FormsModule ,


  ]
})
export class UserModule { }
