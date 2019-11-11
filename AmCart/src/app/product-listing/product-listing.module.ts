import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListingComponent } from './product-listing/product-listing.component';
import { ProductComponent } from './product/product.component';
import { ProductService } from '../services/product.service';



@NgModule({
  declarations: [ProductListingComponent, ProductComponent],
  imports: [
    CommonModule
  ],
  exports: [ProductListingComponent],
  bootstrap: [ProductListingComponent],
  providers:[ProductService]
})
export class ProductListingModule { }
