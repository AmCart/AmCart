import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product-listing/product/product.component';
import { ProductListingComponent } from './product-listing/product-listing/product-listing.component';
import { LoginComponent } from './user-login/login/login.component';
import { RegisterComponent } from './user-login/register/register.component';
import { CartComponent } from './cart/cart/cart.component';


const routes: Routes = [
  {
    path:'login', 
    component: LoginComponent, 
    pathMatch: 'full'
  },
  {
    path:'register', 
    component: RegisterComponent, 
    pathMatch: 'full'
  },
  {
    path:'products', 
    component: ProductListingComponent, 
    pathMatch: 'full'
  },
  {
  path:'details/:id', 
  component: ProductComponent, 
  pathMatch: 'full'
},
{
  path:'cart', 
  component: CartComponent, 
  pathMatch: 'full'
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
