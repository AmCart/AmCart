import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule,HTTP_INTERCEPTORS  } from '../../node_modules/@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListingModule } from './product-listing/product-listing.module';
import { LoginComponent } from './user-login/login/login.component';
import { RegisterComponent } from './user-login/register/register.component';
import { HeaderComponent } from './header/header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtInterceptor } from './helpers/jwt.inceptors';
import { FooterComponent } from './footer/footer/footer.component';
import { CartComponent } from './cart/cart/cart.component';
import { AuthService } from './services/auth.service';
import { OidcSecurityService, AuthModule } from 'angular-auth-oidc-client';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    FooterComponent,
    CartComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ProductListingModule,
    FormsModule,
    ReactiveFormsModule,
    AuthModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    AuthService,
    OidcSecurityService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
