import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct } from '../Models/iproduct';
import { ICategory } from '../Models/icategory';
import { ISubCategory } from '../Models/isub-category';
import { IproductRate } from '../Models/iproduct-rate';
import { ICategoryListIds } from '../Models/i-category-list-ids';


@Injectable({
  providedIn: 'root'
})
export class ProductApiService {
  private productList: IProduct[] = [];

  constructor(private HttpServes:HttpClient) { }

  getAll():Observable<IProduct[]>
  {
    // const httpOptions={
    //   headers:new HttpHeaders({
    //     'content-type': 'application/JSON',
    //     "Access-Control-allow-origion":"*"
     
    //   })}
   return this.HttpServes.get<IProduct[]>(`${environment.APIUrl}/Product/GetAll`);
  }
  getAllcat():Observable<ICategory[]>
  {
    // const httpOptions={
    //   headers:new HttpHeaders({
    //     'content-type': 'application/JSON',
    //     "Access-Control-allow-origion":"*"
     
    //   })}
   return this.HttpServes.get<ICategory[]>(`${environment.APIUrl}/Category/GetAll`);
  }
  getProdByID(prdID:number):Observable<IProduct>
  {
   return this.HttpServes.get<IProduct>(`${environment.APIUrl}/Product/GetProdByID/${prdID}`);
  }
  getProdsByCatID(catID:number):Observable<IProduct[]>
  {
   return this.HttpServes.get<IProduct[]>(`${environment.APIUrl}/Product/GetProdByCatID/${catID}`);
  }
  getProdsBySubCatID(catID:number):Observable<IProduct[]>
  {
   return this.HttpServes.get<IProduct[]>(`${environment.APIUrl}/Product/GetProdBySubCatID/${catID}`);
  }
  GetRateByProdId(prdID:number):Observable<IproductRate[]>
  {
   return this.HttpServes.get<IproductRate[]>(`${environment.APIUrl}/ProductRate/GetRateByProdId/${prdID}`);
  }
  makeComment(prdRate:IproductRate)
  {
    const httpOptions={
      headers:new HttpHeaders({
        'content-type': 'application/JSON',
        "Access-Control-allow-origion":"*",
        "Authorization":`Bearer ${localStorage.getItem("Token")}`
      })}
    return this.HttpServes.post<IproductRate>(`${environment.APIUrl}/ProductRate/Post`,prdRate,httpOptions)//this.shoppingCart$.value)
 
  }
  
  //getProdByCatID(catID:number):Observable<any>
  //{
    // const httpOptions={
    //   headers:new HttpHeaders({
    //     'content-type': 'application/JSON',
    //     "Access-Control-allow-origion":"*"
     
    //   })}
   // if(catID==0)
    //{
    // return this.HttpServes.get<IProduct[]>(`${environment.APIUrl}/product`)
   // }
    //else
   // {
   //   return this.HttpServes.get<IProduct[]>(`${environment.APIUrl}/product?CategoryID=${catID}`);
   // }

 //}
  insertProd(prd:IProduct):Observable<any>
  {
    const httpOptions={
      headers: new HttpHeaders({
        'content-type':'application/JSON'
      })
    }
     return this.HttpServes.post(`${environment.APIUrl}/product`,JSON.stringify(prd),httpOptions)
  }
  updateProd(prdID:number,prd:IProduct)
  {
   // return this.HttpServes.put<any>(`${environment.APIUrl}/${prdID},prd`)
  }
  deleteProd(prdID:number)
  {
   return this.HttpServes.delete<any>(`${environment.APIUrl}/product/${prdID}`)
  }
getrate():Observable<IproductRate[]>
{
  return this.HttpServes.get<IproductRate[]>(`${environment.APIUrl}/ProductRate/GetAll`)
}
geSubCategoriesByCatID(catID:number):Observable<ISubCategory[]>
{
  return this.HttpServes.get<ISubCategory[]>(`${environment.APIUrl}/SubCategory/GetSubCatByCatID/${catID}`)
}



getProdByCatID(catID:ICategoryListIds[]):Observable<any>
{
  // const httpOptions={
  //   headers:new HttpHeaders({
  //     'content-type': 'application/JSON',
  //     "Access-Control-allow-origion":"*"
   
  //   })}
    return this.HttpServes.post<IProduct[]>(`${environment.APIUrl}/Category/GetProdByCatID`, catID);

}
getProdBySubCatID(SubcatIDs:ICategoryListIds[]):Observable<any>
{
  // const httpOptions={
  //   headers:new HttpHeaders({
  //     'content-type': 'application/JSON',
  //     "Access-Control-allow-origion":"*"
   
  //   })}
    return this.HttpServes.post<IProduct[]>(`${environment.APIUrl}/SubCategory/GetProdBySubCatID`, SubcatIDs);

}
}
