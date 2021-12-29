import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders/orders.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { CheckOutFormComponent } from './check-out-form/check-out-form.component';
import { RouterModule } from '@angular/router';
import { NgxPayPalModule } from 'ngx-paypal';
import { UserGuardGuard } from '../UserLogin/user-login/user-guard.guard';
import { MaterialModule } from 'src/app/Materials/material/material.module';

const routes=[
  {path:'Orders',component:OrdersComponent,canActivate:[UserGuardGuard]},
  {path:'Orderdetails/:id',component:OrderDetailsComponent,canActivate:[UserGuardGuard]},
  {path:'checkout',component:CheckOutFormComponent,canActivate:[UserGuardGuard]},
  ]


@NgModule({
  declarations: [
    OrdersComponent,
    OrderDetailsComponent,
    CheckOutFormComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    NgxPayPalModule,
    MaterialModule
  ]
})
export class OrderModule { }
