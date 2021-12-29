import { IProduct } from './iproduct';

export interface ICartInfo {
    ID :number
    ProductID :number
    Quantity :number
    Price :number
    cartID:number
    Product:IProduct
}
