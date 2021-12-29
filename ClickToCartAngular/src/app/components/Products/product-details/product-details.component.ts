import { Component, ElementRef, OnInit,OnChanges, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICartInfo } from 'src/app/Models/icart-info';
import { ICategory } from 'src/app/Models/icategory';
import { IProduct } from 'src/app/Models/iproduct';
import { IproductRate } from 'src/app/Models/iproduct-rate';
import { ISubCategory } from 'src/app/Models/isub-category';
import { RegisterModel } from 'src/app/Models/register-model';
import { ProductApiService } from 'src/app/Services/product-api.service';
import { ShoppingCartService } from 'src/app/Services/shopping-cart.service';
import { SubCatService } from 'src/app/Services/sub-cat.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit,OnChanges{
  isComented:boolean=false
  isSigned:boolean=true
  sentPrdID:number=0;
  prd:IProduct={}as IProduct;
  sendPrd:IProduct={}as IProduct;
  subcat:ISubCategory[]=[];
  catName:ICategory={}as ICategory;
  idcat:number=0;
  prdsub:IProduct[]=[]
  firstName!:string;
catID:number=0;
subId!:number;
currentrate=0;
rateCount!:number;
rateSum:number=0;
rateAve!:number;
prdRate:IproductRate[]=[]
prdcurRate:IproductRate={}as IproductRate
countCart:number=0
clientcommnnt:string="";
clientName:string=localStorage.getItem("Id")||"";
starRating:number;
userData:RegisterModel[]=[];
  constructor(private ApiService:ProductApiService, private shoppingCart:ShoppingCartService,
    private activedRout:ActivatedRoute,
    private router:Router,private sub :SubCatService,private userServ:UserService) { 
      if(localStorage.getItem("Token")!=null){
        this.isSigned=false;
      }
      this.starRating=0;
    }
  ngOnChanges(changes: SimpleChanges): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
    // this.router.navigate(['/product-details', 1]);
    this.activedRout.paramMap.subscribe((param)=>
         {
           this.sentPrdID=Number(param.get('id'));
    this.ApiService.getProdByID(this.sentPrdID).subscribe({
      next:(prd)=>{
       this.sendPrd=prd
       this.ApiService.getProdsBySubCatID(this.sendPrd.SubCategoryID).subscribe((next)=>{
        this.prdsub=next
      });
      this.ApiService.GetRateByProdId(this.sendPrd.ID).subscribe((next)=>{
        this.prdRate=next
        this.rateCount=this.prdRate.length;

        console.log(this.prdRate)
        this.prdRate.forEach(element => {
          // console.log(element.UserId)
          this.rateSum+=element.Rate;
          console.log(element.Rate)
          console.log(this.rateSum)

          this.userServ.getUser(element.UserId).subscribe((next)=>{
            element.UserName=next.UserName;
            // this.userData.push(next)
          })
        });
        this.rateAve=(this.rateSum/this.rateCount)
        console.log(this.rateAve)

      });
      }
      }); 
        });    
        // this.userServ.getUser(localStorage.getItem("Id") || "").subscribe((next)=>{
        //   this.userData=next
        // })   
  }
  async updateQuantity(item:ICartInfo,qty:any)
  {
    qty=qty as ElementRef
    console.log(qty.value,"TTT",item.Product.Price)
    await this.shoppingCart.updateProduct(Number(qty.value),item,item.Product)
     this.shoppingCart.postCartDetails().subscribe({
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
     await this.shoppingCart.decreaseProduct(item)
     this.shoppingCart.postCartDetails().subscribe({
       next:(s)=>{
         console.log(s)
       }
     })
  }
  async increaseQuantity(item:IProduct,qty:any)
  {
    qty=qty as ElementRef
    qty.value++
     await this.shoppingCart.addProduct(item)
     this.shoppingCart.postCartDetails().subscribe({
       next:(s)=>{
         console.log(s)
       }
     })

     this.shoppingCart.getCount().subscribe((c)=>this.countCart=c)
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
  async addComment()
  {
    this.prdcurRate.Comments=this.clientcommnnt;
    this.prdcurRate.Rate=this.starRating;
    this.prdcurRate.productID=this.sentPrdID;
    this.prdcurRate.UserId=this.clientName;
    this.ApiService.makeComment(this.prdcurRate).subscribe(()=>{
      this.isComented=true;
      location.reload()
    })
  }
}
