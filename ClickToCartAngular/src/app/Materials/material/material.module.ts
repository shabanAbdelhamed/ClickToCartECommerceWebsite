import { NgModule } from '@angular/core';

 import{MatButtonModule} from '@angular/material/button';
 import{MatToolbarModule} from '@angular/material/toolbar';
 import{MatIconModule}from '@angular/material/icon';
 import{MatFormFieldModule} from '@angular/material/form-field'
 import {MatGridListModule} from '@angular/material/grid-list';
 import { MatOptionModule  } from '@angular/material/core';
 import{MatInputModule} from '@angular/material/input';
 import {MatCardModule} from '@angular/material/card';
 import {MatSelectModule} from '@angular/material/select';
 import {MatTabsModule} from '@angular/material/tabs';

 


const MatComponents=[

  MatToolbarModule,
   MatButtonModule,
   MatIconModule,
   MatFormFieldModule,
   MatOptionModule,
   MatInputModule,
   MatCardModule,
   MatGridListModule,
   MatSelectModule,
   MatTabsModule

   
]
@NgModule({
 
  imports: [MatComponents],
  exports:[MatComponents]
})
export class MaterialModule { }
