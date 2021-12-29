import {Inject, Component, OnInit,Output, Input, OnChanges, ElementRef ,EventEmitter, AfterContentInit, OnDestroy} from '@angular/core';
import { IOrder } from '../../../Models/iorder';
import { Route, Router,ActivatedRoute } from '@angular/router';
import { OrdersApiService } from '../../../Services/orders-api.service';
import { Subscription } from 'rxjs';
import { IOrderDetails } from '../../../Models/iorder-details';
import { IProduct } from '../../../Models/iproduct';
@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {

  OrderDetails:IOrderDetails[]=[] 
  prdList:IProduct[]=[]
  OrderID:number=0
  subscriptions:Subscription[]=[]
  constructor(
    private orderService:OrdersApiService,
    private activatedRoute:ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.OrderID=Number(this.activatedRoute.snapshot.paramMap.get("id"));
    
      this.subscriptions.push(this.orderService.getOrderDetailsByOrderId(this.OrderID).subscribe({
        next:(orders:IOrderDetails[])=>{
          this.OrderDetails=orders
          console.log(orders)
        },
        error:(err)=>{
          console.log(err);
        }
      }))
  }

}
