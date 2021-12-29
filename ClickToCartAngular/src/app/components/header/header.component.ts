import { Component, OnInit, OnChanges } from '@angular/core';
import { ICategory } from 'src/app/Models/icategory';
import { IProduct } from 'src/app/Models/iproduct';
import { ISubCategory } from 'src/app/Models/isub-category';
import { RegisterModel } from 'src/app/Models/register-model';
import { SubCatService } from 'src/app/Services/sub-cat.service';

import { ProductApiService } from 'src/app/Services/product-api.service';
import { ShoppingCartService } from 'src/app/Services/shopping-cart.service';
import { UserService } from 'src/app/Services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnChanges {
  ResultObject: any;
  isUsrLogged: boolean = false;
  user: RegisterModel = {} as RegisterModel;
  catList: ICategory[] = []
  subcatList: ISubCategory[] = []
  countCart: number = 0
  filteredOptions!: string;
  prdlist: IProduct[] = []
  searchInput: String = '';
  searchResult: Array<any> = [];
  firstName:string="My Account";
  constructor(private userServ:UserService,private ApiServ:ProductApiService,
    private cartService:ShoppingCartService,private SubCat:SubCatService,
    private router:Router
  ) {
    this.userServ.getIsLogged().subscribe({
      next: (logStatus: boolean) => {
        this.isUsrLogged = logStatus;
      }
    });

    this.ApiServ.getAllcat().subscribe((next) => {
      this.catList = next
      for (const cat of this.catList) {

      }
    })
    this.ApiServ.getAll().subscribe((next) => {
      this.prdlist = next
    })
    // this.SubCat.getSubCategoryByCatID(id).subscribe((next)=>{
    //   this.subcatList=next
    // })
  if(localStorage.getItem("Result")!=null)
    this.firstName=JSON.parse(localStorage.getItem("Result") || "").FirstName;
   }

   ngOnChanges()
   {
    
  //       try{
  //         debugger
  //       //var _result = localStorage.getItem("Result");
  //       this.ResultObject =  localStorage.getItem("Result");
  //       console.log("============================================");
  //       console.log(this.ResultObject);
  //       this.firstName = this.ResultObject.FirstName;
  //       //this.firstName =  _result == null ? "" : _result.FirstName;
  //   }
  //   catch (Error){
  //     console.log(Error);
  //  }
   
  }

  ngAfterViewChecked() {
    this.userServ.getIsLogged().subscribe({
      next: (logStatus: boolean) => {
        this.isUsrLogged = logStatus
        this.updateCount()
      }
    });
  }
  ngOnInit(): void {



  }
  updateCount() {
    if (this.isUsrLogged) {
      this.cartService.getCount().subscribe({
        next: (count) => {
          //console.log("More Than Zero")
          this.countCart = count
        }
      });
    }
    else if (!this.isUsrLogged && localStorage.getItem("cart") != null) {
      this.cartService.getCount().subscribe({
        next: (count) => {
          //console.log("More Than Zero")
          this.countCart = count
        }
      });
    }
    else {
      // console.log("Zero")
      this.countCart = 0
    }

  }
  logout() {
    this.userServ.setIsLogged(false)
    localStorage.removeItem("Id")
    localStorage.removeItem("Token")
    localStorage.removeItem("Result")
    this.router.navigateByUrl("/")
    this.cartService.emptyCart()
  }
  mouseEnter(Catid: number) {
    this.SubCat.getSubCategoryByCatID(Catid).subscribe((next) => {
      this.subcatList = next
    })
  }
  fetchSeries(event: any): any {
    debugger
    if (event.target.value === '') {
      return this.searchResult = [];
    }
    debugger
    this.searchResult = this.prdlist.filter((series) => {
      return series.Name.toLowerCase().startsWith(event.target.value.toLowerCase());
    })
  }

  // fetchSeries(event: any):any {
  //   if (event.target.value === '') {
  //     return this.searchResult = [];
  //   }
  //   this.searchResult = this.prdlist.filter((series) => {
  //     return series.Name.toLowerCase().startsWith(event.target.value.toLowerCase());
  //   })
  // }

}
