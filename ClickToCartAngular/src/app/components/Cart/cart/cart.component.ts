import { Component, OnInit, ElementRef, OnChanges } from '@angular/core';
import { ShoppingCartService } from '../../../Services/shopping-cart.service';
import { ICartInfo } from '../../../Models/icart-info';
import {Observable} from 'rxjs'
import { ShoppingCart } from '../../../Models/shopping-cart';
import { IProduct } from '../../../Models/iproduct';
import { UserService } from '../../../Services/user.service';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit ,OnChanges{
  totalPrice:number=0
  totalItems:number=0
  shoppingCart:ShoppingCart={} as ShoppingCart
  countCart:number=0
  //qty:number=0
  constructor(private cartService:ShoppingCartService,
  private uservice:UserService
  ) {
    // this.cartService.getAllItems(14).subscribe({
    //   next:(cInfo:ShoppingCart)=>
    //   {
    //     this.shoppingCart=cInfo
    //   }
    // })
    
   }
ngOnChanges()
{

}
  ngOnInit(): void {
    this.cartService.getCount().subscribe((c)=>this.countCart=c)
    this.cartService.getTotalPrice().subscribe((c)=>this.totalPrice=c)
    this.uservice.getIsLogged().subscribe({
        next:(r)=>{
          this.cartService.getItems().subscribe((c)=> this.shoppingCart.CartDetailsItems=c)

        }
    })
   
  }
  ngAfterViewChecked()	
  {
    this.uservice.getIsLogged().subscribe({
      next: (logStatus:boolean)=>{
        this.cartService.getItems().subscribe((c)=>{
          this.shoppingCart.CartDetailsItems=c
          // console.log(this.shoppingCart.CartDetailsItems)
        } )

      }
    });
  }
  async deleteItem(item:ICartInfo)
{
  console.log(this.shoppingCart.CartDetailsItems)
  console.log(item)
await this.cartService.deleteItem(item)
this.cartService.postCartDetails().subscribe({
  next:(s)=>{
   // console.log(s)
  }
})
}
  async updateQuantity(item:ICartInfo,qty:any)
  {
    qty=qty as ElementRef
    await this.cartService.updateProduct(Number(qty.value),item,item.Product)
     this.cartService.postCartDetails().subscribe({
       next:(s)=>{
         console.log(s)
       }
     })
  }
  async decreaseQuantity(item:IProduct,qty:any)
  {
    qty=qty as ElementRef
    if(qty.value > 1)
       qty.value--
     await this.cartService.decreaseProduct(item)
     this.cartService.postCartDetails().subscribe({
       next:(s)=>{
         console.log(s)
       }
     })
  }
  async increaseQuantity(item:IProduct,qty:any)
  {
    qty=qty as ElementRef
    qty.value++
     await this.cartService.addProduct(item)
     this.cartService.postCartDetails().subscribe({
       next:(s)=>{
         console.log(s)
       }
     })

     this.cartService.getCount().subscribe((c)=>this.countCart=c)
     //this.cartService.getQuantityForProduct(item as IProduct).subscribe((c)=>this.qty=c)

    }


}
