import { Component, OnInit } from '@angular/core';
import {IPayPalConfig,ICreateOrderRequest } from 'ngx-paypal';
import { ElementRef, OnChanges } from '@angular/core';
import { ShoppingCartService } from '../../../Services/shopping-cart.service';
import { ICartInfo } from '../../../Models/icart-info';
import {Observable} from 'rxjs'
import { ShoppingCart } from '../../../Models/shopping-cart';
import { IProduct } from '../../../Models/iproduct';
import { OrdersApiService } from '../../../Services/orders-api.service';
import { IOrderViewModel } from '../../../Models/iorder-view-model';
import {  UserService} from '../../../Services/user.service';
import { Router } from '@angular/router';
import { DiscountService } from 'src/app/Services/discount.service';

@Component({
  selector: 'app-check-out-form',
  templateUrl: './check-out-form.component.html',
  styleUrls: ['./check-out-form.component.scss']
})
export class CheckOutFormComponent implements OnInit {
    IsPayPal :boolean=true;
    placeOrderbool:boolean=false;
    IsPaiedPayPal :boolean=false;
  public payPalConfig ? : IPayPalConfig;
  totalPrice:number=0
  subtotalPrice:number=0;
  OrderView:IOrderViewModel={} as IOrderViewModel
  totprc:string='';
  shoppingCart:ShoppingCart={} as ShoppingCart;
  CheckDiscount:boolean=false;
  discountRate!:number;
  discountValue!:number;
  couponNotValid:boolean=false;
  discountValidationMessage!:string;
  disenableCoupon:boolean=false;
  constructor(private cartService:ShoppingCartService,
 private orderService:OrdersApiService,
 private router:Router,private discountService:DiscountService,
 private uservice:UserService
) {
    
    // this.cartService.getAllItems(14).subscribe({
    //   next:(cInfo:ShoppingCart)=>
    //   {
    //     this.shoppingCart=cInfo
    //   }
    // })
   }
  ngOnInit(): void {
    this.cartService.getTotalPrice().subscribe((c)=>{
        this.totalPrice=c;
        this.subtotalPrice=this.totalPrice;
        this.totprc=this.totalPrice.toString();
        this.OrderView.OrderStatus=false
        this.OrderView.TotalPrice=c
        this.OrderView.shippingID=1
        this.OrderView.PaymentId=1
            this.OrderView.UserID!=localStorage.getItem("Id");
})

    this.cartService.getItems().subscribe((c)=> this.shoppingCart.CartDetailsItems=c)

    this.initConfig();
}
  
private initConfig(): void {
          this.payPalConfig = {
              currency: 'USD',
              clientId: 'AahuUbtSjePElbuxkqwequaMNPmdi-ldvVziaCA02K04XO3iBPoH8fcfkMhKewkGDRYWs49tCimSh-2i',
              createOrderOnClient: (data) => < ICreateOrderRequest > {
                  intent: 'CAPTURE',
                  purchase_units: [{
                      amount: {
                          currency_code: 'USD',
                          value: this.totprc ,
                          breakdown: {
                              item_total: {
                                  currency_code: 'USD',
                                  value: this.totprc
                              }
                          }
                      },
                      items: [{
                          name: 'Enterprise Subscription',
                          quantity: '1',
                          category: 'DIGITAL_GOODS',
                          unit_amount: {
                              currency_code: 'USD',
                              value: this.totprc,
                          },
                      }]
                  }]
              },
              advanced: {
                  commit: 'true'
              },
              style: {
                  label: 'paypal',
                  layout: 'vertical',
                  size: 'small',
                  shape: 'rect',
                  color: 'silver',
              },
              onApprove: (data, actions) => {
                  console.log('onApprove - transaction was approved, but not authorized', data, actions);
                  this.IsPaiedPayPal=true;
                  this.placeOrderbool=true
                  console.log("this is after payment is done")
                  actions.order.get().then((details:any) => {
                      console.log('onApprove - you can get full order details inside onApprove: ', details);
                      
                    
                    });
  
              },
              onClientAuthorization: (data) => {
                  console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
                this.placeOrder()
                },
              onCancel: (data, actions) => {
                  console.log('OnCancel', data, actions);
              },
              onError: err => {
                  console.log('OnError', err);
              },
              onClick: (data, actions) => {
                  console.log('onClick', data, actions);
              }
          };
  }
  checkPaypal(){
      this.IsPayPal=true;
      this.placeOrderbool=false;
}  
uncheckPaypal(){
    this.IsPayPal=false;
    this.placeOrderbool=true;
}  
placeOrder(){
    if (this.placeOrderbool==true) {
       
        this.orderService.makeOrder(this.OrderView).subscribe({
            next:(resp)=>
            {
                console.log(resp.success)
                if(resp.success){
                    this.cartService.emptyCart()
                    this.uservice.setIsLogged(true)
                    this.router.navigateByUrl(`/Orderdetails/${resp.data}`)
                }
               
                
               //
            }
        })
    }
}
//   private initConfig(): void {
//     this.payPalConfig = {
//         currency: 'USD',
//         clientId: 'AahuUbtSjePElbuxkqwequaMNPmdi-ldvVziaCA02K04XO3iBPoH8fcfkMhKewkGDRYWs49tCimSh-2i',
//         createOrderOnClient: (data) => < ICreateOrderRequest > {
//             intent: 'CAPTURE',
//             purchase_units: [{
//                 amount: {
//                     currency_code: 'USD',
//                     value: '9.99',
//                     breakdown: {
//                         item_total: {
//                             currency_code: 'USD',
//                             value: '9.99'
//                         }
//                     }
//                 },
//                 items: [{
//                     name: 'Enterprise Subscription',
//                     quantity: '1',
//                     category: 'DIGITAL_GOODS',
//                     unit_amount: {
//                         currency_code: 'USD',
//                         value: '9.99',
//                     },
//                 }]
//             }]
//         },
//         advanced: {
//             commit: 'true'
//         },
//         style: {
//             label: 'paypal',
//             layout: 'vertical',
//             size: 'small',
//             shape: 'rect',
//             color: 'silver',
//         },
//         onApprove: (data, actions) => {
//             console.log('onApprove - transaction was approved, but not authorized', data, actions);
//             actions.order.get().then((details:any) => {
//                 console.log('onApprove - you can get full order details inside onApprove: ', details);
//             });

//         },
//         onClientAuthorization: (data) => {
//             console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
//         },
//         onCancel: (data, actions) => {
//             console.log('OnCancel', data, actions);

//         },
//         onError: err => {
//             console.log('OnError', err);
//         },
//         onClick: (data, actions) => {
//             console.log('onClick', data, actions);
//         }
//     };
// }
ApplyCoupon(code:any){
    this.discountService.getDiscountByName(code.value).subscribe((discount)=>{
      if(discount!=null){
        var dateFrom = new Date(discount.Start_Date);
        var dateTo = new Date(discount.End_Date);
        var dateCheck = new Date();
         if(dateCheck > dateFrom && dateCheck < dateTo){
            this.discountRate=discount.Number;
            this.discountValue=(this.totalPrice*discount.Number)/100;
          this.totalPrice-=this.discountValue;
          this.totprc=this.totalPrice.toString();
          this.CheckDiscount=true;
          this.OrderView.TotalPrice=this.totalPrice;
          this.disenableCoupon=true;
         }
         else{
             this.discountValidationMessage="Expired Coupon ";
             this.couponNotValid=true;
         }
         
      }
      else{
        this.discountValidationMessage="Invalid Coupon";
       this.couponNotValid=true;
      }
    });
}
}
