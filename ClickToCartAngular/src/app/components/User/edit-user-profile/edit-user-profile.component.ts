import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IProfileUpdate } from 'src/app/Models/iprofile-update';
import { RegisterModel } from 'src/app/Models/register-model';

import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-edit-user-profile',
  templateUrl: './edit-user-profile.component.html',
  styleUrls: ['./edit-user-profile.component.scss']
})
export class EditUserProfileComponent implements OnInit {
  isLogin:boolean=false;
  isUsrLogged:boolean = false;
  user:RegisterModel={} as RegisterModel
  UpdateForm!:FormGroup;
  ProfileUpdate!:IProfileUpdate
  newPassword!:string;
  constructor(private userServ:UserService,private route:Router,
    private fb:FormBuilder,private activeRout:ActivatedRoute) { }

  ngOnInit(): void {

    this.userServ.loginStatusSubject().subscribe({
      next: (logStatus)=>{
        this.isUsrLogged=logStatus;
      }
    });
    this.userServ.getUser(localStorage.getItem("Id") || "").subscribe((next)=>{
      this.user=next
    })
    this.UpdateForm= this.fb.group({
      UserName: [this.user.UserName, [Validators.required, Validators.minLength(3),Validators.maxLength(30)]],
      FirstName: [this.user.FirstName, [Validators.required, Validators.minLength(3),Validators.maxLength(30)]],
      LastName: [this.user.LastName, [Validators.required, Validators.minLength(3),Validators.maxLength(30)]],

      Email: [this.user.Email, [Validators.required, Validators.email]],
      NewPassword:[this.user.Password,[Validators.required,
        Validators.minLength(5)
      ,Validators.maxLength(10)]],      
      oldPassword:[this.user.Password,[Validators.required,
        Validators.minLength(5)
      ,Validators.maxLength(10)]],
      PhoneNumber:[this.user.PhoneNumber,[Validators.required,Validators.minLength(6),
                                          Validators.maxLength(11),Validators.pattern('(01)(1|2|0)[0-9]{8}')]],
      Address:[this.user.Address,[Validators.required,Validators.maxLength(30)]],
      
    })
    this.resetForm;
  }
  logout()
  {
    this.userServ.logout();
    this.userServ.getIsLogged().subscribe((next)=>
    this.isLogin=next);
    this.route.navigateByUrl('/Home');

  }
  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.ProfileUpdate = {
      Id:'',
      UserName: '',
      FirstName:'',
      LastName:'',
      oldPassword: '',
      NewPassword:'',
      Email: '',
      PhoneNumber: 0,
     Address:''
    }
  }
update()
{
  this.ProfileUpdate={
    Id:localStorage.getItem("Id")||"",
    UserName:this.user.UserName,
    FirstName:this.UpdateForm.controls["FirstName"].value,
    LastName:this.UpdateForm.controls["LastName"].value,
    Email:this.UpdateForm.controls["Email"].value,
    oldPassword:this.UpdateForm.controls["oldPassword"].value,
    NewPassword:this.UpdateForm.controls["NewPassword"].value,
    PhoneNumber:this.UpdateForm.controls["PhoneNumber"].value,
    Address:this.UpdateForm.controls["Address"].value
  }
  console.log(this.ProfileUpdate)
  this.userServ.Update(this.ProfileUpdate).subscribe(
    (next)=>{
      console.log(next)
      
  this.route.navigateByUrl('/User/MyProfile')

    }
  )
}
  
}
