import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product-listing/product/product.component';
import { ProductListingComponent } from './product-listing/product-listing/product-listing.component';


const routes: Routes = [
  {
    path:'products', 
    component: ProductListingComponent, 
    pathMatch: 'full'
  },
  {
  path:'details/:id', 
  component: ProductComponent, 
  pathMatch: 'full'
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
