import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICategoryListIds } from 'src/app/Models/i-category-list-ids';
import { IProduct } from 'src/app/Models/iproduct';
import { ISubCategory } from 'src/app/Models/isub-category';
import { ProductApiService } from 'src/app/Services/product-api.service';
import { ShoppingCartService } from 'src/app/Services/shopping-cart.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit ,OnChanges{
  public page = 1;
  public pageSize=9;
  filteredOptions!: string;
  min:number=10;
  max:number=10;
  SelectedSubCategory:number=0;
  subCatList:ISubCategory[]=[];
  prdsList:IProduct[]=[];
  allPrdList:IProduct[]=[];
  fPrdList:IProduct[]=[];
  subCategoryIdsList: ICategoryListIds[] = [];
  constructor(private ApiServes:ProductApiService,private ActiveRouter:ActivatedRoute,
    private shoppingCart:ShoppingCartService) { }
  ngOnChanges(changes: SimpleChanges): void {
    
  }
  
  ngOnInit(): void {
    this.ActiveRouter.paramMap.subscribe(params=>{
      this.ApiServes.getProdsByCatID(Number(params.get("id"))).subscribe((Products)=>{
        
        this.prdsList=Products;
        this.allPrdList=this.prdsList;
        
      });
      this.ApiServes.geSubCategoriesByCatID(Number(params.get("id"))).subscribe((Products)=>{
        
        this.subCatList=Products;
        
       
      });
    })
  
  }
  // ChangeSubCat(){
  //   if(this.SelectedSubCategory!=0){
  //     this.ApiServes.getProdsBySubCatID(this.SelectedSubCategory).subscribe((prds)=>{
  //       this.prdsList=prds;
  //       //
  //       console.log(this.prdsList);

  //     });
      
  //    }
  //    else{
  //      this.prdsList=this.allPrdList;
  //    }
  //    this.prdsList.sort(function(a:IProduct, b:IProduct) {
  //     return a.ID - b.ID;
  //   });
  //    this.fPrdList=this.prdsList;
  // }
  async addToCart(Product:IProduct)
  {
   
    await this.shoppingCart.addProduct(Product)
    // .subscribe({
    //   next:(s)=>{
    //     console.log(s)
    //   }
    // })
   this.shoppingCart.postCartDetails().subscribe({
     next:(s)=>{
       console.log(s)
     }
   })
  }
  checkCheckBoxvalue(event:any,Id:number,allprd:any){
    //alert(event.target.checked)
    if(event.target.checked){
      allprd.checked=false;
      this.subCategoryIdsList.push({
        id: Id
      });
 
 
    }else{
      // this.categoryIdsList.indexOf({
      //   id: Id
      // });
      this.subCategoryIdsList=this.subCategoryIdsList.filter(x=>x.id!=Id)
      // this.categoryIdsList.pop({
      //   id: Id
      // });
    }
    if(this.subCategoryIdsList.length>0){
      this.ApiServes.getProdBySubCatID(this.subCategoryIdsList).subscribe((respons)=>{
        this.prdsList=respons
        this.prdsList.sort(function(a:IProduct, b:IProduct) {
          return a.ID - b.ID;
        });
        this.fPrdList=this.prdsList;
      });
    }
    else{
      this.prdsList=this.allPrdList;     
      this.prdsList.sort(function(a:IProduct, b:IProduct) {
        return a.ID - b.ID;
      });
      this.fPrdList=this.prdsList;

    }
  }
  AllProducts(event:any){
    console.log(event)
    if(event.target.checked){
      
    this.prdsList=this.allPrdList;
    }
  }
  FilterPrice(){
        // this.fPrdList=this.prdsList;

    if(this.fPrdList.length==0){
      this.prdsList=this.allPrdList.filter(p=>p.Price>=this.min&&p.Price<=this.max)
    }
    else{
      this.prdsList=this.fPrdList.filter(p=>p.Price>=this.min&&p.Price<=this.max)
    }    
  }
  CheckValue(event:any){
    
    if(event.target.value<this.min) {
      
      this.max=this.min;
    }
  }
}
