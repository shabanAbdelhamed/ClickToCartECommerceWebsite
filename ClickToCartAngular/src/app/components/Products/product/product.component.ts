import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { IProduct } from 'src/app/Models/iproduct';
import { ProductApiService } from 'src/app/Services/product-api.service';
import {ShoppingCartService} from 'src/app/Services/shopping-cart.service';
import { ShoppingCart } from '../../../Models/shopping-cart';
import { UserService } from '../../../Services/user.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit,OnChanges {
@Input() prdList:IProduct[]=[];
prdsList!:IProduct[];
proListSelCat:IProduct[]=[];
filteredOptions!:string;
starRating:number = 0; 
//@Input() selectedCatId:number=0;
public page = 1;
public pageSize=9;


  constructor(private APiServes:ProductApiService,
    private router:Router,
    private shoppingCart:ShoppingCartService
  ) {

  
   }

  //  ngOnInit(){

  //  }
  ngOnChanges(changes: SimpleChanges): void {
    
      this.prdsList =this.prdList;

    
    //this.prdsList =this.prdList;

    //console.log(this.prdsList);
    // if(this.selectedCatId==0){
    //   this.APiServes.getAll().subscribe({
    //     next:(products)=>{
    //      this.prdList=products;
    //   // this.proListSelCat=this.prdList
    //     }
    //    });
      
    // }else{
    //   this.APiServes.getProdByCatID(this.selectedCatId).subscribe((next) => {
    //     console.log(next);
    //     this.prdList=next;
    //   });
    // }

   
  }

  ngOnInit(): void {

    //  this.APiServes.getAll().subscribe({
    //   next:(products)=>{
    //    this.prdList=products;
    //  //this.proListSelCat=this.prdList
    //   }
    //  });

    //  debugger
    //  if(this.selectedCatId==0){
    //   this.APiServes.getAll().subscribe({
    //     next:(products)=>{
    //      this.prdList=products;
    //   // this.proListSelCat=this.prdList
    //     }
    //    });
      
    // }else{
    //   this.APiServes.getProdByCatID(this.selectedCatId).subscribe((next) => {
    //     console.log(next);
    //     this.prdList=next;
    //   });
    // }

    }
    prdDetails(prdID:any)
    {
     
     this.router.navigate(['/Products',prdID])
    }
    async addToCart(Product:IProduct)
    {
     
      await this.shoppingCart.addProduct(Product)
      // .subscribe({
      //   next:(s)=>{
      //     console.log(s)
      //   }
      // })
     this.shoppingCart.postCartDetails().subscribe()
    }
}
