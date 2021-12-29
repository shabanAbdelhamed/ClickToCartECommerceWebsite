import { Injectable } from '@angular/core';
import {IOrder} from '../Models/iorder'
import { HttpClient,HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs'
import { environment } from '../../environments/environment';
import { IOrderDetails } from '../Models/iorder-details';
import { IOrderViewModel } from '../Models/iorder-view-model';
import { Token } from '@angular/compiler';
import { ResultViewModel } from '../Models/result-view-model';
import { IOrderStatus } from '../Models/iorder-status';
@Injectable({
  providedIn: 'root'
})
export class OrdersApiService {

  constructor(private client:HttpClient) { }


  getOrdersByUserID(userID:string):Observable<IOrder[]>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*"
     
      })}
    return this.client.get<IOrder[]>(`${environment.APIUrl}/order/GetByUserId/${userID}`,httpOptions)
  }
  getOrdersStatusByID(ordID:number):Observable<IOrderStatus>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*"
     
      })}
    return this.client.get<IOrderStatus>(`${environment.APIUrl}/order/GetStatusByUserId/${ordID}`,httpOptions)
  }
  getOrderDetailsByOrderId(ID:number):Observable<IOrderDetails[]>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*"
     
      })}
    return this.client.get<IOrderDetails[]>(`${environment.APIUrl}/orderdetails/GetById/${ID}`,httpOptions)
  }
  makeOrder(oderView:IOrderViewModel):Observable<ResultViewModel>
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*",
        "Authorization":`Bearer ${localStorage.getItem("Token")}`
      })}
    return this.client.post<ResultViewModel>(`${environment.APIUrl}/Order/Post`,oderView,httpOptions)//this.shoppingCart$.value)
 
  }

}
