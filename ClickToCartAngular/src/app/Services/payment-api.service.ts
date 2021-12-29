import { Injectable } from '@angular/core';
import {IOrder} from '../Models/iorder'
import { HttpClient,HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs'
import { environment } from '../../environments/environment';
import { IPayment } from '../Models/Ipayment';
@Injectable({
  providedIn: 'root'
})
export class PaymentApiService {

  constructor(private client:HttpClient) { }

  getPaymentByID(ID:number):Observable<IPayment>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*"
     
      })}
    return this.client.get<IPayment>(`${environment.APIUrl}/payment/getbyid/${ID}`,httpOptions)
  }
  getall():Observable<IPayment[]>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*"
     
      })}
    return this.client.get<IPayment[]>(`${environment.APIUrl}/payment/getall`,httpOptions)
  }

}
