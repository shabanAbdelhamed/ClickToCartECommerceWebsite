import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxPayPalModule } from 'ngx-paypal';

 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProductComponent } from './components/Products/product/product.component';
import { ProductDetailsComponent } from './components/Products/product-details/product-details.component';
import { HomeComponent } from './components/home/home.component';

import { HttpClientModule } from '@angular/common/http';

import { MaterialModule } from './Materials/material/material.module';

import { UserLoginComponent } from './components/UserLogin/user-login/user-login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserRegisterComponent } from './components/Register/user-register/user-register.component';
import { AllProductComponent } from './components/Products/all-product/all-product.component';
import { SearchPipe } from './components/Pipe/search.pipe';
import { SubcategoryComponent } from './components/subCategory/subcategory/subcategory.component';
import { OrderModule } from './components/order/order.module';
import { CartComponent } from './components/Cart/cart/cart.component';
import { FiltercheskPipe } from './components/Pipe/filterchesk.pipe';
import { MdbCarouselModule } from 'mdb-angular-ui-kit/carousel';
import { CategoryComponent } from './components/category/category.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ProductComponent,
    ProductDetailsComponent,
    HomeComponent,
   
    UserLoginComponent,
    UserRegisterComponent,
    AllProductComponent,
    SearchPipe,
    SubcategoryComponent,
    CartComponent,
    FiltercheskPipe,
    CategoryComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxPayPalModule,
    FormsModule ,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    MdbCarouselModule,
    OrderModule,
    NgbModule,


  
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
