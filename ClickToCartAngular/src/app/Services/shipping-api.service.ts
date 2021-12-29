import { Injectable } from '@angular/core';
import {IOrder} from '../Models/iorder'
import { HttpClient,HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs'
import { environment } from '../../environments/environment';
import { IShipping } from '../Models/ishipping';

@Injectable({
  providedIn: 'root'
})
export class ShippingApiService {

  constructor(private client:HttpClient) { }

  getShippingByID(id:number):Observable<IShipping>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*"
     
      })}
    return this.client.get<IShipping>(`${environment.APIUrl}/Shipping/GetById/${id}`,httpOptions)
  }
  getall():Observable<IShipping[]>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*"
     
      })}
    return this.client.get<IShipping[]>(`${environment.APIUrl}/Shipping/GetAll`,httpOptions)
  }
}
