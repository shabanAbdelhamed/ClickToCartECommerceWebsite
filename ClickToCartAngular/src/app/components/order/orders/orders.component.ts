import {Inject, Component, OnInit,Output, Input, OnChanges, ElementRef ,EventEmitter, AfterContentInit, OnDestroy} from '@angular/core';
import { IOrder } from '../../../Models/iorder';
import { Route, Router,ActivatedRoute } from '@angular/router';
import { OrdersApiService } from '../../../Services/orders-api.service';
import { Subscription } from 'rxjs';
import { IShipping } from '../../../Models/ishipping';
import { IPayment } from '../../../Models/Ipayment';
import { ShippingApiService } from '../../../Services/shipping-api.service';
import { PaymentApiService } from '../../../Services/payment-api.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit,OnChanges {
  orders:IOrder[]=[]
 userID:string=localStorage.getItem("Id")||"1"
 shippings:IShipping[]=[]
 payments:IPayment[]=[]
  private subscriptions: Subscription[]=[]
  constructor(
    private orderService:OrdersApiService,
    private activatedRoute:ActivatedRoute,
    private router:Router,
    private shippingService:ShippingApiService,
    private PaymentService:PaymentApiService,
  ) { }

  ngOnInit(): void {
    
      this.subscriptions.push(this.orderService.getOrdersByUserID(this.userID).subscribe({
        next:(orders:IOrder[])=>{
          this.orders=orders
        },
        error:(err)=>{
          console.log(err);
        }
      })) 
      this.subscriptions.push(this.PaymentService.getall().subscribe({
        next:(Payments:IPayment[])=>{
          this.payments=Payments
        },
        error:(err)=>{
          console.log(err);
        }
      })) 
      this.subscriptions.push(this.shippingService.getall().subscribe({
        next:(shippings:IShipping[])=>{
          this.shippings=shippings
        },
        error:(err)=>{
          console.log(err);
        }
      })) 
  }
ngOnChanges()
{
 
}
getPaymentName(id:number)
{
   let name:string="Cash1"
  this.payments.map(item=>{
    if(item.Id==id)
    name= item.payment_type
  })

  return name
  // let name:string="Cash"
  // let p:IPayment={ } as IPayment
  // this.PaymentService.getPaymentByID(id).subscribe({
  //   next:(payment:IPayment)=>
  //   {
  //    return payment.payment_type
  //   }
  // })
 // return name;
}
getShippingName(id:number)
{
  let name:string="Cash"
  this.shippings.map(item=>{
    if(item.ID==id)
       name= item.Name
  })
  // let name:string="Train"
  // this.shippingService.getShippingByID(id).subscribe({
  //   next:(shipping:IShipping)=>
  //   {
  //    return shipping.Name
     
  //   }
  // })
 return name;
}

}
