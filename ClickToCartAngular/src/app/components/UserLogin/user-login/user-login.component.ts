import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
//import {ResultViewModel} from '../../Modelsresult-view-model'
import { UserService } from 'src/app/Services/user.service';
import { ResultViewModel } from '../../../Models/result-view-model';
import { ShoppingCartService } from '../../../Services/shopping-cart.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {
  hide: boolean = true;
  isLogin:boolean=true;
  
  private _returnUrl: string="";
resultModel:ResultViewModel={} as ResultViewModel
  constructor(private fb: FormBuilder,private route:Router
    ,private userServ:UserService,
    private _route: ActivatedRoute,
   private cartService:ShoppingCartService
  ) { }

  ngOnInit(): void {
   // console.log(this.isLogin)
   this._returnUrl = this._route.snapshot.queryParams['returnUrl'] ;
  }
  loginForm: FormGroup = this.fb.group({
    Username: ['', [Validators.required, Validators.minLength(3)]],
    Password: ['', [Validators.required, Validators.minLength(6)]]
  })


  // onLogin() {
  //   if (!this.loginForm.valid) {
  //     return;
  //   }
  //   this.userServ.login("AA", "123");
  //   this.isLogin=this.userServ.loginStatus();
  //   this.route.navigateByUrl('/Home');
  // }

   login(form:NgForm)
  {
   
   const test={} as any
this.userServ.Login(form.value).subscribe({
   next: (r:any)=>{
    if(r.success)
    {
     
      console.log("======================Login data ======================");
      console.log(r);
     this.userServ.setIsLogged(r.success)
     localStorage.setItem("Id", r.data.Id)
     localStorage.setItem("Result",JSON.stringify(r.data))
    // localStorage.setItem("Result",r.data);
     localStorage.setItem("Token",r.data.Token)
     this.cartService.updateCart()
     
     this.route.navigateByUrl(this._returnUrl);
    // console.log(r.data.Id)
    }
    
    console.log(this.isLogin)
    this.userServ.getIsLogged().subscribe({
      next:(r:boolean)=>{ this.isLogin=r
        
      }
    })
  },
  error:(e)=>{
    if(e.status ==500)
     alert("Error in Server Or your Connection  not stable")
  },
  complete:()=>{
    if(this.isLogin)
    {
      this.cartService.updateCart()
      this.cartService.emptyCart()
      this.route.navigateByUrl(this._returnUrl);
    }
     
  } 
  });
  
}

  logout()
  {
    
    this.userServ.logout();
    this.userServ.setIsLogged(false)
    this.cartService.emptyCart()
    this.route.navigateByUrl(this._returnUrl);
  }

}
