import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductListingComponent implements OnInit {
  constructor(private productService : ProductService,    
    private router: Router) {
    this.productService.displayProducts(); 
  }

  ngOnInit() {
    
  }
   
  getDetails(url,id){
    debugger;
    this.router.navigateByUrl(`${url}/${id}`)
  }

}