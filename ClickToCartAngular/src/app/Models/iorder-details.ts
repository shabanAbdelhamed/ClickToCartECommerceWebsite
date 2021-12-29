import { IProduct } from './iproduct';

export interface IOrderDetails {
     ID :number
     Product :IProduct
     Quantity :number
     Price :number
     orderID :number
}
