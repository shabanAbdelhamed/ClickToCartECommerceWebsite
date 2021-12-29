import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IDscount } from '../Models/idscount';
import { IProduct } from '../Models/iproduct';

@Injectable({
  providedIn: 'root'
})
export class DiscountService {

  constructor(private httpServ:HttpClient) { }
 
  getDiscount():Observable<IProduct[]>
  {
    return this.httpServ.get<IProduct[]>(`${environment.APIUrl}/Discount/All`)
  }
  getDiscountByName(name:string):Observable<IDscount>{
    return this.httpServ.get<IDscount>(`${environment.APIUrl}/Discount/GetDiscountByName/${name}`); 
  }

}
