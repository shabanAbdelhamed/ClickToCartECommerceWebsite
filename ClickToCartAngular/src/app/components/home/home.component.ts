import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
// import { nextTick } from 'process';
import { ICategory } from 'src/app/Models/icategory';
import { IDscount } from 'src/app/Models/idscount';
import { IProduct } from 'src/app/Models/iproduct';
import { ISubCategory } from 'src/app/Models/isub-category';
import { DiscountService } from 'src/app/Services/discount.service';
import { ProductApiService } from 'src/app/Services/product-api.service';
import { ShoppingCartService } from 'src/app/Services/shopping-cart.service';
import { SubCatService } from 'src/app/Services/sub-cat.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
 catList:ICategory[]=[]
subcat:ISubCategory[]=[]
subcatLi:ISubCategory[]=[]

prddiscount:IProduct[]=[]
discountnum:number=0;
 CatID:number=0;
 prdList:IProduct[]=[]
 prdListF8:IProduct[]=[]
 prdListS5:IProduct[]=[]
 prdListS8:IProduct[]=[];
prdDisconts:IProduct[]=[];
test!:number;
test2!:number;
  constructor(private ApiServ:ProductApiService,private userServ:UserService,private activedRout:ActivatedRoute,private router:Router
    ,private subserv:SubCatService,private discount:DiscountService,
    private shoppingCart:ShoppingCartService) { 
  this.ApiServ.getAllcat().subscribe((next)=>{
    this.catList=next
  })
  this.ApiServ.getAll().subscribe((next)=>{
    this.prdList=next
    this.prdListS8=this.prdList.slice(0,8)
    this.prdListF8=this.prdList.slice(8, 16);
    this.prdListS5=this.prdList.slice(6, 12);
   // console.log(this.prdListF8)
   // console.log(this.prdListS5)
  })

  }

  ngOnInit(): void {
    // this.userServ.logout();    

    this.discount.getDiscount()
    .subscribe((next)=>{
      
      this.prddiscount=next
      this.prdDisconts=this.prddiscount.slice(0,6)
     //console.log (this.prddiscount)
           });
   
    this.subserv.getsub().subscribe((next)=>{
      this.subcat=next
      this.subcatLi=this.subcat.slice(0,12)
      console.log(this.subcatLi)
    });

  
  
  }

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
  
}
