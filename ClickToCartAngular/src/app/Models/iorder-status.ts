import { IOrder } from "./iorder";
import { IStatus } from "./istatus";

export interface IOrderStatus {
    ID:number;
    Status:IStatus;
    Order:IOrder;
    StatusDate:Date;
}
