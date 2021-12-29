import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICategory } from '../Models/icategory';
import { ISubCategory } from '../Models/isub-category';

@Injectable({
  providedIn: 'root'
})
export class SubCatService {

  constructor(private httpServ:HttpClient) { }


  getsub():Observable<ISubCategory[]>
  {
    return  this.httpServ.get<ISubCategory[]>(`${environment.APIUrl}/SubCategory/GetAll`)
  }
  // getSubCategoryByCatID(CatID:number):Observable<any>{

  //   return this.httpServ.get<ISubCategory>(`${environment.APIUrl}/SubCategory?CategoryID=${CatID}`)
  // }
  getSubCategoryByCatID(CatID:number):Observable<ISubCategory[]>{

    return this.httpServ.get<ISubCategory[]>(`${environment.APIUrl}/SubCategory/GetSubCatByCatID/${CatID}`)
  }
  getCat():Observable<ICategory[]>{
    return this.httpServ.get<ICategory[]>(`${environment.APIUrl}/Category/GetAll`)
  }

  getcatbysubcat(id:any):Observable<ISubCategory>{
    return this.httpServ.get<any>(`${environment.APIUrl}/SubCategory/getcat/${id}`)
  }
  getSubCatbyID(id:any):Observable<any>{
    return this.httpServ.get<ISubCategory>(`${environment.APIUrl}/SubCategory/GetSubCatByID/${id}`)
  }
  

}
