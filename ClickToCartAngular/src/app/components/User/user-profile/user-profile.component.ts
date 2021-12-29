import { Component, OnInit } from '@angular/core';
import { RegisterModel } from 'src/app/Models/register-model';

import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  isUsrLogged:boolean = false;
userData!:RegisterModel;

  constructor(private userServ:UserService) { }

  ngOnInit(): void {
    this.userServ.loginStatusSubject().subscribe({
      next: (logStatus)=>{
        this.isUsrLogged=logStatus;
      }
    });
    this.userServ.getUser(localStorage.getItem("Id") || "").subscribe((next)=>{
      this.userData=next
    })
  } 



}
