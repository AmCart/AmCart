import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.authService.initAuth();
  }

  login(){
    this.authService.login();
    // this.router.navigateByUrl('/login')
  }

  register(){
    this.router.navigateByUrl('/register')
  }

  
  getDetails(url){
    this.router.navigateByUrl(`${url}`)
  }

  getCartDetails(url){
    this.router.navigateByUrl(`${url}`)
  }
}
