import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnChanges } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProfileUpdate } from '../Models/iprofile-update';
import { RegisterModel } from '../Models/register-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isLoggedSubject: BehaviorSubject<boolean>;
  constructor(private http: HttpClient) {
    this.isLoggedSubject = new BehaviorSubject<boolean>(false);
    if (localStorage.getItem("Id") !== null) {
      this.isLoggedSubject = new BehaviorSubject<boolean>(true);
    }
    else
      this.isLoggedSubject = new BehaviorSubject<boolean>(false);
  }
  // login(email:string,password:string)
  // {
  // let  userToken="0000fdfdf-ddde4444-987eeeeee";
  // localStorage.setItem('userToken',userToken);
  // this.isLoggedSubject.next(true);
  // return true;
  // }
  setIsLogged(value: boolean) {
    this.isLoggedSubject.next(value)
    if (!value) {
      localStorage.removeItem("Id")
    }
  }
  // getItems(): Observable<ICartInfo[]> {
  //   return this.shoppingCart1$.pipe(
  //     pluck('CartDetailsItems')
  //   );
  // }
  getIsLogged(): Observable<boolean> {
    return this.isLoggedSubject.pipe()
  }
  Login(formdata: any): Observable<any> {
    return this.http.post(`${environment.APIUrl}/User/Login`, formdata)
  }
  Register(Register: RegisterModel) {
    const body: RegisterModel = {
      UserName: Register.UserName,
      FirstName: Register.FirstName,
      LastName: Register.LastName,
      Email: Register.Email,
      Password: Register.Password,
      PhoneNumber: Register.PhoneNumber,
      Address: Register.Address
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'contact-type': 'application/json',
      })
    }
    return this.http.post(`${environment.APIUrl}/User/Register`, body, httpOptions)
  }
  logout() {
    debugger
    localStorage.removeItem('Id');
    localStorage.removeItem('Token');
    localStorage.removeItem('Result');
    this.setIsLogged(false)

  }
  getUser(userID: string): Observable<RegisterModel> {
    const httpOptions = {
      headers: new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion": "*",
        "Authorization": `Bearer ${localStorage.getItem("Token")}`
      })
    }
    return this.http.get<RegisterModel>(`${environment.APIUrl}/User/GetUser/${userID}`, httpOptions)
  }
  Update(upProfile: IProfileUpdate): Observable<any> {
    // const body:IProfileUpdate={
    //     Id:upProfile.Id,
    //     UserName:upProfile.UserName,
    //     FirstName:upProfile.FirstName,
    //     LastName:upProfile.LastName,
    //     Email:upProfile.Email,
    //     oldPassword:upProfile.oldPassword,
    //     NewPassword:upProfile.NewPassword,
    //     PhoneNumber:upProfile.PhoneNumber,
    //     Address:upProfile.Address
    // }
    const httpOptions = {
      headers: new HttpHeaders({
        'contact-type': 'application/json',
        "Access-Control-allow-origion": "*",
        "Authorization": `Bearer ${localStorage.getItem("Token")}`
      })
    }
    return this.http.post<any>(`${environment.APIUrl}/User/UpdateProfile`, upProfile, httpOptions)
  }


  // loginStatus():boolean
  // {
  //   if(localStorage.getItem('Id'))
  //   {
  //   return true;
  //   }
  //   else
  //   { 
  //   return false;

  //   }
  // }

  loginStatusSubject(): Observable<boolean> {
    return this.isLoggedSubject.asObservable();
  }


}
