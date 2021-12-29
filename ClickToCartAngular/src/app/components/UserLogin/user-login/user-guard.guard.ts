import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

import { UserService } from 'src/app/Services/user.service';

@Injectable({
  providedIn: 'root'
})
export class UserGuardGuard implements CanActivate {
   isLogged!:boolean;

  constructor(private userServ:UserService,
    private route:Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree 
    {
      this.userServ.getIsLogged().subscribe((next)=>{
        this.isLogged=next
      });
      if(!this.isLogged)
      {
        this.route.navigate(['/Login'])
        return false;
      }
      return true;
  }
  
}
