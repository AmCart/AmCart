import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AmCart';

  constructor(private router: Router) {}

  getDetails(url,id){
    debugger;
    this.router.navigateByUrl(`${url}`)
  }
}
