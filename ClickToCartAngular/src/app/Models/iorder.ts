import { IOrderStatus } from "./iorder-status";

export interface IOrder {
    ID: number
 OrderStatus: boolean
 PaymentID: number
 shippingID: number
 TotalPrice: number
 UserID: number
 OrderStatuss:IOrderStatus;
 }