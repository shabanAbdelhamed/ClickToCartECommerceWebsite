export interface IProduct {
ID:number;
Name: string;
Price :number;
ImgCoverURl: string;

des:string;
SubCateogryID : number;

Description:string;
SubCategoryID :number;

// Description:string;
// SubCategoryID :number;

TagID:number;
DiscountID:number;
SubCategory:ISubCategory;

Qunatity:number;
}
export interface ISubCategory {
    ID:number
    Name:string
    }