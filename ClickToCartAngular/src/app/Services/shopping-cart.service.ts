import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { IProduct } from '../Models/iproduct';
import { map, pluck, elementAt, count } from 'rxjs/operators';
import { ShoppingCart } from '../Models/shopping-cart';
import { environment } from '../../environments/environment';
import { ICartInfo } from '../Models/icart-info';
import { IShoppingCart } from '../Models/ishopping-cart';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  private shoppingCart1$:BehaviorSubject<ShoppingCart>;
  private shoppingCart$:BehaviorSubject<ShoppingCart>;
  private checkout$:BehaviorSubject<boolean>;
//private shoppingCartWithProduct$:BehaviorSubject<ShoppingCart>;
  constructor(
    private httpClient: HttpClient
  ) { 
    // if(localStorage.getItem("Id") !== undefined)
    // {
    
      this.shoppingCart$ = new BehaviorSubject<ShoppingCart>({ UserID:"" , CartDetailsItems: [], });
      this.shoppingCart1$ = new BehaviorSubject<ShoppingCart>({ UserID:"", CartDetailsItems: [], });
      this.checkout$ = new BehaviorSubject<boolean>(false);

      this.getShoppingCart(); 
      this.getShoppingCart1(); 
    
   // else
  //  this.isLoggedSubject = new BehaviorSubject<boolean>(false);
    
    //  GetFromCartWithProduct
  //this.shoppingCartWithProduct$ = new BehaviorSubject<ShoppingCart>({ UserID:12 , CartDetailsItems: [], });
  
    
  }
  setCheckOut(v:boolean)
  {
    this.checkout$.next(v)
  }
  getCheckOut():Observable<boolean>
  {
   return this.checkout$
  }
  private setShoppingCart1(s:ShoppingCart)
  {
    this.shoppingCart1$.next(s)
  }
  private setShoppingCart(shoppingCart: ShoppingCart) 
  {
    this.shoppingCart$.next(shoppingCart);
   // const httpOptions={
      // headers:new HttpHeaders({
      //   'content-type': 'application/JSON',
      //   "Access-Control-allow-origion":"*"
     
      // })}
      // return this.httpClient.post(
      //   `${environment.APIUrl}/Cart/AddToCart/`,
      //   this.shoppingCart$.value
      // ); 
      // { headers: new HttpHeaders({
      //   'content-type': 'application/JSON',
      //   "Access-Control-allow-origion":"*"
     
      // })
    
    //console.log(this.postCartDetails(this.shoppingCart$.value))
  }
   postCartDetails():Observable<any>
  {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    let s= this.shoppingCart$.value as ShoppingCart
    //console.log(this.shoppingCart$.value)
    if(localStorage.getItem("Id") !=null)
  {
     return this.httpClient.post<ShoppingCart>(`${environment.APIUrl}/Cart/AddToCart`,s)}
  else{
   localStorage.setItem("cart",JSON.stringify(this.shoppingCart1$.value))
   console.log(this.shoppingCart1$.value)
    return this.shoppingCart1$
  }
     // .subscribe(()=>{
    //   this.getShoppingCart1()

    // })//this.shoppingCart$.value)
  }
   updateCart()
  {
    this.getShoppingCart1()
    this.getShoppingCart()
  
  //  for(let i of )
  //  {
  //   console.log(++c)
  //   await this.addProductFromCart(i,i.Product)
  //     localStorage.removeItem("cart")
  //  }
      
  }
addItemsFromCart()
{
  // this.setShoppingCart1(this.shoppingCart1$.value)
  //alert(JSON.stringify(this.shoppingCart1$.value))
    let c=0
    let cartFromLocal:ShoppingCart={} as ShoppingCart
    if(localStorage.getItem("cart")!=null)
    { cartFromLocal=JSON.parse(localStorage.getItem("cart")||"{}")
    cartFromLocal.UserID=localStorage.getItem("Id")||""
    cartFromLocal.CartDetailsItems.forEach(i => {
      console.log(this.shoppingCart1$.value)
        //  setInterval(()=>{
            this.addProductFromCart(i,i.Product)
         // },500)      
    });
    localStorage.removeItem("cart")
    
}
    //  for(let i of cartFromLocal.CartDetailsItems)
    //  {
    //    console.log("addPro")
    //   await this.addProduct(i.Product)
    //  }
    // }
   //  let pIds:number[]=[]
   // const shoppingCart1={...cartFromLocal}
   // shoppingCart1.CartDetailsItems.concat(cartFromLocal.CartDetailsItems)
  // for(let i of cartFromLocal.CartDetailsItems)
  // {
  //   shoppingCart1.CartDetailsItems.push(i)
  // }
    // shoppingCart1.CartDetailsItems = shoppingCart1.CartDetailsItems.map((item) => {
    //   c++
    //   let res=cartFromLocal.CartDetailsItems.filter((i)=>
    //   {

    //     console.log(item.ProductID,c)
    //     console.log(i.ProductID,c)
    //     if( i.ProductID === item.ProductID)
    //         return i
    //     else
    //        return null
    //   })
    //   let res1=cartFromLocal.CartDetailsItems.filter((i)=>i.ProductID !== item.ProductID)
      
    //   if(res.length>0) {
    //     if(pIds.indexOf(item.ProductID)==-1)
    //     {
    //       console.log("Identical")
    //       item.Price+=res[0].Price
    //       item.Quantity+=res[0].Quantity
    //     }
    //     pIds.push(item.ProductID)
        
    //   }
    //   if(c == 1){
    //    // shoppingCart1.CartDetailsItems.push(...res1)
        
    //   }
    //   // item.Quantity = item.ID === updateItem.ID ? updateQuantity : item.Quantity;
    //    // item.Price=item.ID===updateItem.ID ?prd.Price*updateQuantity:item.Price
    //     return item;
    //   });
    //this.getCount()
   //this.getTotalPrice()
   //console.log(shoppingCart1)
   //this.setShoppingCart1(shoppingCart1)
  }
  private getShoppingCart1() {
    
    if(localStorage.getItem("Id")!==null)
    {
      this.httpClient.get<ShoppingCart>(`${environment.APIUrl}/Cart/GetFromCartWithProduct/${localStorage.getItem("Id")}`).subscribe({
        next:(shoppingCart:ShoppingCart) => {
          //,...JSON.parse(localStorage.getItem("cart")||"{}")
        this.setShoppingCart1(shoppingCart)
        
       if(localStorage.getItem("cart")!=null)
           this.addItemsFromCart()
       
      },
     error: () => {
        console.error('Shopping cart data could not be loaded.')
      },
    })
    }
    else if(localStorage.getItem("cart") !== null){
     
    let t=localStorage.getItem("cart")
    let s:ShoppingCart=JSON.parse(t||"{}")
    this.setShoppingCart1(s)
  }
  
   
   
  }
  private getShoppingCart() {
    
    if(localStorage.getItem("Id") !== null)
    {
      this.httpClient.get<ShoppingCart>(`${environment.APIUrl}/Cart/GetFromCart/${localStorage.getItem("Id")}`).subscribe({
        next:(shoppingCart:ShoppingCart) => {
        this.setShoppingCart(shoppingCart)
        if(localStorage.getItem("cart")!=null)
           this.addItemsFromCart()
      },
     error: () => {
        console.error('Shopping cart data could not be loaded.')
      },
    })
    }
    else if(localStorage.getItem("cart") !== null){
      let t=localStorage.getItem("cart")
      let s:ShoppingCart=JSON.parse(t||"{}")
      this.setShoppingCart(s)
    }
    
  }
 getAllItems(userId:string):Observable<ShoppingCart>
{
 // if(localStorage.getItem("Id")!=null)
  return this.httpClient.get<ShoppingCart>(`${environment.APIUrl}/Cart/GetFromCartWithProduct/${userId}`)
 
}
  getItems(): Observable<ICartInfo[]> {
  // this.getShoppingCart1()
  //  this.getShoppingCart()
    return this.shoppingCart1$.pipe(
      pluck('CartDetailsItems')
    );
    
  }
  addProductFromCart(cartInfo1:ICartInfo,Productr: IProduct)//:Observable<any>
  {
    //alert(JSON.stringify(this.shoppingCart1$.value))
    console.log(cartInfo1)
    console.log(Productr)
    let index:number=-1
    let cartInfo:ICartInfo={} as ICartInfo
    let cartInfo2:ICartInfo={} as ICartInfo
    cartInfo.ProductID=Productr.ID
    cartInfo2.ProductID=Productr.ID
    cartInfo.Price=cartInfo1.Price
    cartInfo2.Price=cartInfo1.Price
    cartInfo2.Quantity=cartInfo1.Quantity
    cartInfo.Quantity=cartInfo1.Quantity
    cartInfo2.Product=cartInfo1.Product
    console.log(this.shoppingCart1$.value)
    const shoppingCart = { ...this.shoppingCart$.value };
    const shoppingCart1 = { ...this.shoppingCart1$.value };
    
    shoppingCart1.CartDetailsItems = shoppingCart1.CartDetailsItems.map((item) => {
    if(item.ProductID==cartInfo1.ProductID)
        {
           console.log(item.ProductID)
          item.Quantity+=cartInfo1.Quantity
          item.Price=item.Quantity*Productr.Price
     //     cartInfo=item
          index=1
        }
     return item;
    });
    shoppingCart.CartDetailsItems = shoppingCart.CartDetailsItems.map((item) => {
      //console.log(item.Product)
     // item.quantity = item.id === updateItem.id ? +updateQuantity : item.quantity;
    if(item.ProductID == cartInfo1.ProductID)
        { 
          item.Quantity+=cartInfo1.Quantity
          item.Price=item.Quantity*Productr.Price
          //cartInfo=item
          index=1
        }
     return item;
    });
    if(index==-1)
    {
     shoppingCart.CartDetailsItems.push(cartInfo)
     shoppingCart1.CartDetailsItems.push(cartInfo2)
    }
   
    this.setShoppingCart(shoppingCart);
    console.log(shoppingCart1)
   // this.setShoppingCart1(shoppingCart1);
    this.setShoppingCart1(shoppingCart1)
    console.log(shoppingCart)
 // return  this.httpClient.post<ShoppingCart>(`${environment.APIUrl}/Cart/AddToCart`,shoppingCart,httpOptions)
   // console.log(this.shoppingCart$)
  }
  addProduct(Productr: IProduct)//:Observable<any>
  {
    
    let index:number=-1
    let cartInfo:ICartInfo={} as ICartInfo
    let cartInfo2:ICartInfo={} as ICartInfo
    cartInfo.ProductID=Productr.ID
    cartInfo.Quantity=1
    cartInfo.Price=Productr.Price
    cartInfo2.ProductID=Productr.ID
    cartInfo2.Quantity=1
    cartInfo2.Price=Productr.Price
    cartInfo2.Product=Productr
    
    const shoppingCart = { ...this.shoppingCart$.value };
    const shoppingCart1 = { ...this.shoppingCart1$.value };
    
    shoppingCart1.CartDetailsItems = shoppingCart1.CartDetailsItems.map((item) => {
    if(item.ProductID==Productr.ID)
        { item.Quantity++
          item.Price=item.Quantity*Productr.Price
          cartInfo=item
          index=1
        }
     return item;
    });
    shoppingCart.CartDetailsItems = shoppingCart.CartDetailsItems.map((item) => {
      //console.log(item.Product)
     // item.quantity = item.id === updateItem.id ? +updateQuantity : item.quantity;
    if(item.ProductID==Productr.ID)
        { item.Quantity++
          item.Price=item.Quantity*Productr.Price
          cartInfo=item
          index=1
        }
     return item;
    });
    if(index==-1)
    {shoppingCart.CartDetailsItems.push(cartInfo)
     shoppingCart1.CartDetailsItems.push(cartInfo2)
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };
    this.setShoppingCart(shoppingCart);
    //console.log(shoppingCart)
   // this.setShoppingCart1(shoppingCart1);
    this.setShoppingCart1(shoppingCart1)
    //console.log(shoppingCart)
 // return  this.httpClient.post<ShoppingCart>(`${environment.APIUrl}/Cart/AddToCart`,shoppingCart,httpOptions)
   // console.log(this.shoppingCart$)
  }
  decreaseProduct(Productr:IProduct)
  {
    const shoppingCart = { ...this.shoppingCart$.value };
    const shoppingCart1 = { ...this.shoppingCart1$.value };
   
    shoppingCart1.CartDetailsItems = shoppingCart1.CartDetailsItems.map((item) => {
      if(item.ProductID==Productr.ID)
          {if(item.Quantity>1)
            {
              item.Quantity--
            item.Price=item.Quantity*Productr.Price
            }
          }
       return item;
      });
    shoppingCart.CartDetailsItems = shoppingCart.CartDetailsItems.map((item) => {
    if(item.ProductID==Productr.ID)
        {if(item.Quantity>1)
          {
            item.Quantity--
          item.Price=item.Quantity*Productr.Price
          }
        }
     return item;
    });
   
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };
    this.setShoppingCart(shoppingCart);
    this.setShoppingCart1(shoppingCart1);

  }
  updateProduct(updateQuantity: number, updateItem:ICartInfo,prd:IProduct) {
  //  console.log(updateItem)
    const shoppingCart = { ...this.shoppingCart$.value };
    shoppingCart.CartDetailsItems = shoppingCart.CartDetailsItems.map((item) => {
    //  console.log(item.Price)
      item.Quantity = item.ID === updateItem.ID ? updateQuantity : item.Quantity;
      item.Price=item.ID===updateItem.ID ?prd.Price*updateQuantity:item.Price
      return item;
    });
    const shoppingCart1 = { ...this.shoppingCart1$.value };
    shoppingCart1.CartDetailsItems = shoppingCart1.CartDetailsItems.map((item) => {
    //  console.log(item.Price)
      item.Quantity = item.ID === updateItem.ID ? updateQuantity : item.Quantity;
      item.Price=item.ID===updateItem.ID ?prd.Price*updateQuantity:item.Price
      return item;
    });
    //console.log(this.shoppingCart$.value)
    this.setShoppingCart(shoppingCart);
    this.setShoppingCart1(shoppingCart1);
  }
  getCount(): Observable<number> {
  
    // return this.shoppingCart$.pipe(
    //   map((shoppingCart) => {
    //     const count = shoppingCart.CartDetailsItems.length
    //     return count;
    //   })
    // );
   
    return this.shoppingCart$.pipe(
      map((shoppingCart) => {
        const count = shoppingCart.CartDetailsItems
          .map((item:ICartInfo) => item.Quantity)
          .reduce((p, c) => p + c, 0);
        return count;
      })
    );
  }
 
 emptyCart(){
  const shoppingCart1 = { ...this.shoppingCart1$.value };
  shoppingCart1.CartDetailsItems = shoppingCart1.CartDetailsItems.filter((item) => item.ProductID ==null);
  const shoppingCart = { ...this.shoppingCart$.value };
  shoppingCart.CartDetailsItems = shoppingCart.CartDetailsItems.filter((item) => item.ProductID == null);
  
this.setShoppingCart(shoppingCart1)
this.setShoppingCart1(shoppingCart)
 } 
getTotalPrice(): Observable<number> {
    return this.shoppingCart1$.pipe(
      map((shoppingCart) => {
        const subTotal = shoppingCart?.CartDetailsItems
          .map((item:ICartInfo) =>{
            if(item.Quantity!=0)
             return item.Quantity * item.Product.Price//item.Quantity
            else
             return item.Quantity
            })
          .reduce((p, c) => p + c, 0);
        return subTotal;
      })
    );
  }

  deleteItem(deleteItem: ICartInfo) {
    console.log(deleteItem)
    const shoppingCart1 = { ...this.shoppingCart1$.value };
    shoppingCart1.CartDetailsItems = shoppingCart1.CartDetailsItems.filter((item) => deleteItem.ProductID !== item.ProductID);
    
    const shoppingCart = { ...this.shoppingCart$.value };
    shoppingCart.CartDetailsItems = shoppingCart.CartDetailsItems.filter((item) => deleteItem.ProductID !== item.ProductID);
    
    this.setShoppingCart(shoppingCart);
    this.setShoppingCart1(shoppingCart1);

  }
 
}
