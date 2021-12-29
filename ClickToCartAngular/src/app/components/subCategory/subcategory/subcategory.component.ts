import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICategory } from 'src/app/Models/icategory';
import { IProduct } from 'src/app/Models/iproduct';
import { ISubCategory } from 'src/app/Models/isub-category';
import { ProductApiService } from 'src/app/Services/product-api.service';
import { ShoppingCartService } from 'src/app/Services/shopping-cart.service';
import { SubCatService } from 'src/app/Services/sub-cat.service';

@Component({
  selector: 'app-subcategory',
  templateUrl: './subcategory.component.html',
  styleUrls: ['./subcategory.component.scss']
})
export class SubcategoryComponent implements OnInit ,OnChanges{
  public page = 1;
public pageSize=9;
  prdsub:IProduct[]=[]
  allPrdSub:IProduct[]=[]
  subCatID:number=0;
  subCatName!:string;
  min:number=10;
  max:number=10;
  filteredOptions!: string;
  @Input()SeleCatID:number=0;
  constructor(private activedRout:ActivatedRoute,
   private SubCat:SubCatService,private prdServ:ProductApiService, private shoppingCart:ShoppingCartService ) { }
  ngOnChanges(changes: SimpleChanges): void {
    
  }

  ngOnInit(): void {
  
    this.activedRout.paramMap.subscribe((params)=>{
      this.subCatID=Number(params.get('id'))
      this.SubCat.getSubCatbyID(this.subCatID).subscribe((SubCat)=>{
        console.log(SubCat);
        this.subCatName = SubCat.Name;
      })
     this.subCatID=Number(this.prdServ.getProdsBySubCatID(this.subCatID).subscribe((next)=>{
        this.prdsub=next
        this.allPrdSub=this.prdsub;
       
      }));
    })
    
   
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

FilterPrice(){
  console.log(this.max)
  this.prdsub=this.allPrdSub;
  this.prdsub=this.allPrdSub.filter(p=>p.Price>=this.min&&p.Price<=this.max)
}
CheckValue(event:any){
  
  if(event.target.value<this.min) {
    
    this.max=this.min;
  }
}

}

