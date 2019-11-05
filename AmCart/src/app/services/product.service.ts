import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { ProductItem } from '../models/product-item';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url = 'http://localhost:3000/products';
  products$: BehaviorSubject<ProductItem[]> = new BehaviorSubject([]);
  public product:ProductItem;
  constructor(private http:HttpClient) { }

  displayProducts(){
    return this.http.get<ProductItem[]>(`${this.url}`).subscribe(data => { 
      this.products$.next(data);
    });
  }

  getItem(id){
    return this.http.get(`${this.url}/${id}`);
  }
}
