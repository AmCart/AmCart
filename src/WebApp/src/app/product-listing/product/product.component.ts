import { Component, OnInit, Input } from '@angular/core';
import { ProductItem } from '../../models/product-item';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  public product:ProductItem;
  public currentProductId : number;

  constructor(private productService:ProductService, 
    private route: ActivatedRoute) {
   }

  ngOnInit() {
    this.route.params.subscribe(param=>{
      debugger;
      this.currentProductId = param.id;
      this.productService.getItem(this.currentProductId).subscribe(
        data => this.product = data as ProductItem
      );
    });
  }

  
}
