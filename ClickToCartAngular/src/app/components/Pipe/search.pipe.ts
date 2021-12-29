import { Pipe, PipeTransform } from '@angular/core';
import { IProduct } from 'src/app/Models/iproduct';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(Products: IProduct[], filteredOptions: String): IProduct[] {
    if(!Products || !filteredOptions){
      return Products;
    }
    return Products.filter(prd=>prd.Name.toLocaleLowerCase()
    .includes(filteredOptions.toLocaleLowerCase()));
  }

}
