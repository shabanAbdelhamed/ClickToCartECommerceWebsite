import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './components/Cart/cart/cart.component';
import { CategoryComponent } from './components/category/category.component';
import { HomeComponent } from './components/home/home.component';
import { AllProductComponent } from './components/Products/all-product/all-product.component';
import { ProductDetailsComponent } from './components/Products/product-details/product-details.component';
import { ProductComponent } from './components/Products/product/product.component';
import { UserRegisterComponent } from './components/Register/user-register/user-register.component';
import { SubcategoryComponent } from './components/subCategory/subcategory/subcategory.component';
import { UserLoginComponent } from './components/UserLogin/user-login/user-login.component';
import { UserLoginGuard } from './components/Guards/user-login.guard';

const routes: Routes = [
  {path:'', redirectTo:'/Home', pathMatch:'full'}, //Default path
  {path:'Home', component:HomeComponent},
  {path:'Product',component:AllProductComponent},
  {path:'Login',component:UserLoginComponent,canActivate:[UserLoginGuard]},
  {path:'SignUp',component:UserRegisterComponent, canActivate:[UserLoginGuard]},
  {path:'product/:id',component:ProductDetailsComponent},
  {path:'Category/:id',component:CategoryComponent},
  {path:'SubCategory/:id',component:SubcategoryComponent},
  {path:'Cart',component:CartComponent},


  {
    path: 'Order', 
    loadChildren: () => import('src/app/components/order/order.module')
                        .then(o => o.OrderModule)
  },
  
  {
    path: 'User', 
    loadChildren: () => import('src/app/components/User/user.module')
    .then(u => u.UserModule)

  },
    
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
