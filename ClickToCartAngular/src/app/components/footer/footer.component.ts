import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/Models/icategory';
import { SubCatService } from 'src/app/Services/sub-cat.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
catlist:ICategory[]=[]
  constructor(private cat:SubCatService) { }

  ngOnInit(): void {
    this.cat.getCat().subscribe((next)=>{
      this.catlist=next;
    })
  }

}
