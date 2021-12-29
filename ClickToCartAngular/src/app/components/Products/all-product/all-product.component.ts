import { Component, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { ICategoryListIds } from 'src/app/Models/i-category-list-ids';
import { ICategory } from 'src/app/Models/icategory';
import { IProduct } from 'src/app/Models/iproduct';
import { IproductRate } from 'src/app/Models/iproduct-rate';
import { ISubCategory } from 'src/app/Models/isub-category';
import { ProductApiService } from 'src/app/Services/product-api.service';
import { SubCatService } from 'src/app/Services/sub-cat.service';

@Component({
  selector: 'app-all-product',
  templateUrl: './all-product.component.html',
  styleUrls: ['./all-product.component.scss']
})
export class AllProductComponent implements OnInit,OnChanges {
  min:number=10;
  max:number=10;
  catlist:ICategory[]=[];
  subCat:ISubCategory[]=[];
  prodRate:IproductRate[]=[];
  myControl = new FormControl();
  prdList: IProduct[] = [];
  fprdList: IProduct[] = [];
  sparePrdList:IProduct[]=[];
  sparesubCat:ISubCategory[]=[];
  categoryIdsList: ICategoryListIds[] = [];
  filteredOptions!: string;
 // @ViewChild('myCheckbox') myCheckbox!:number;
selctsubcat!:number;
  SelectedCategory:number=0;
    constructor(private ApiServes:ProductApiService,private subServ:SubCatService) {
      
     }
  ngOnChanges(changes: SimpleChanges): void {
    
    // this.ApiServes.getProdByCatID(this.SelectedCategory).subscribe((respons)=>{
    //   this.prdList=respons
    // })
  }
  checkCheckBoxvalue(event:any,Id:number){
    //alert(event.target.checked)
    if(event.target.checked){
      this.selctsubcat=Id;
      this.categoryIdsList.push({
        id: Id
      });
 
 
    }else{
      // this.categoryIdsList.indexOf({
      //   id: Id
      // });
      this.categoryIdsList=this.categoryIdsList.filter(x=>x.id!=Id)
      // this.categoryIdsList.pop({
      //   id: Id
      // });
    }
    if(this.categoryIdsList.length>0){
      this.ApiServes.getProdBySubCatID(this.categoryIdsList).subscribe((respons)=>{
        this.prdList=respons
        this.prdList.sort(function(a:IProduct, b:IProduct) {
          return a.ID - b.ID;
        });
        //console.log(this.prdList);
  this.fprdList=this.prdList
      });
      

    }
    else{
      if(this.SelectedCategory==0){
        this.prdList=this.sparePrdList;
        this.prdList.sort(function(a:IProduct, b:IProduct) {
          return a.ID - b.ID;
        });
      this.fprdList=this.prdList

      }

      // else{
      //   this.ApiServes.getProdsByCatID(this.SelectedCategory).subscribe((products)=>{
      //     this.prdList=products;
      //   }); 
      // }
    }

    
  }
  ngOnInit(): void {
    this.ApiServes.getAll().subscribe((products)=>{
      this.prdList=products;
      this.sparePrdList=this.prdList;
    });
    this.ApiServes.getAllcat().subscribe({
      next:(cat)=>{
        this.catlist=cat;
        
        //console.log(this.catlist);
      }
    });       
    // this.ApiServes.getAll().subscribe({
    //   next:(prd)=>{
    //     this.prdList=prd
    //   }
    // }); 
    this.subServ.getsub().subscribe({
      next:(cat)=>{
        this.subCat=cat;
        this.sparesubCat=this.subCat;
      }
    }); 
    this.ApiServes.getrate().subscribe({
      next:(rate)=>{
        this.prodRate=rate
      }
    }); 
  }
  GetSubCatBySelection(){
    if(this.SelectedCategory==0){
      this.subCat=this.sparesubCat;
      this.prdList=this.sparePrdList; 
    }
    else{
      this.ApiServes.geSubCategoriesByCatID(this.SelectedCategory).subscribe((Subcats)=>{
        this.subCat=Subcats;
        
      });
      this.ApiServes.getProdsByCatID(this.SelectedCategory).subscribe((products)=>{
        this.prdList=products;
        this.fprdList=this.prdList
      }); 
    }
    this.categoryIdsList=[];
    //this.fprdList=this.prdList

  }
  FilterPrice(){
    console.log(this.fprdList)
    if(this.fprdList.length==0){
      this.prdList=this.sparePrdList.filter(p=>p.Price>=this.min&&p.Price<=this.max)
      console.log(this.prdList)
      console.log("if")

    }
    else{
      this.prdList=this.fprdList.filter(p=>p.Price>=this.min&&p.Price<=this.max)
      console.log(this.prdList)
      console.log("else")

    }    
  }
  CheckValue(event:any){
    
    if(event.target.value<this.min) {
      
      this.max=this.min+1;
    }
  }

}
