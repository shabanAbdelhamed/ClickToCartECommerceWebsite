import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/Services/user.service';

@Injectable({
  providedIn: 'root'
})
export class UserLoginGuard implements CanActivate {
  isLogged!:boolean;
  constructor(private userServ:UserService,
    private route:Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
   {
    this.userServ.getIsLogged().subscribe((v:boolean)=>{
      this.isLogged=v
    });
    if(this.isLogged)
    {
      this.route.navigate(['/'])
      return false;
    }
    return true;
  }
}
}
