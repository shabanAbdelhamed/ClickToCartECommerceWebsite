import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterModel } from 'src/app/Models/register-model';

import { UserService } from 'src/app/Services/user.service';
import { RegisterMessage } from '../../../Models/register-message';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent implements OnInit {
user :RegisterModel=new RegisterModel();
RegisterForm!:FormGroup;
hide: boolean = true;
Errors:RegisterMessage[]=[]
Succeeded:boolean=true
  constructor(private FB:FormBuilder,private userServ:UserService,private rout:Router) { }

  ngOnInit(): void {
    this.RegisterForm= this.FB.group({
      UserName: [this.user.UserName, [Validators.required, Validators.minLength(3),Validators.maxLength(30)]],
      FirstName: [this.user.FirstName, [Validators.required, Validators.minLength(3),Validators.maxLength(30)]],
      LastName: [this.user.LastName, [Validators.required, Validators.minLength(3),Validators.maxLength(30)]],

      Email: [this.user.Email, [Validators.required, Validators.email]],
      Password:[this.user.Password,[Validators.required,
                                    Validators.minLength(5)
                                  ,Validators.maxLength(10)]],
      PhoneNumber:[this.user.PhoneNumber,[Validators.required,Validators.minLength(6),
                                          Validators.maxLength(11)]],
      Address:[this.user.Address,[Validators.required,Validators.maxLength(30)]],
      //,Validators.pattern('(01)(1|2|0)[0-9]{8}')
    })
    //this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.user = {
      UserName: '',
      FirstName:'',
      LastName:'',
      Password: '',
      Email: '',
      PhoneNumber: 0,
     Address:''
    }
  }
  Register(form:NgForm)
  {
    //console.log(form.value)
    let response:any={}
this.userServ.Register(form.value).subscribe({
next:(resp:any)=>{
              response=resp
              if (resp.Succeeded == true) {
              this.resetForm(form);
            this.rout.navigateByUrl('/Login')
            }
            else {
            
            this.Errors=resp.Errors
            this.Succeeded=resp.Succeeded
            console.log(this.Errors)
            }
            },
  error:(e)=>{
    alert(e)
  }
})
};
ConfirmedPass(control: AbstractControl): { [key: string]: boolean } | null {

  if (control.value !== undefined && (control.value === this.RegisterForm.controls['ConfirmedPassword'].value)) {
      return { 'confirmed': true };
  }
  return null;
}
}

