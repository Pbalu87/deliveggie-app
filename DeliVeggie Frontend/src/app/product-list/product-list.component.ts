import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../models/product-model';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: ProductModel[] = [];
  loading: boolean = true;  

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.loading = true;
    this.productService.getAll().subscribe((products: ProductModel[]) => {
      this.products = products;
      this.loading = false;
    }, error => {
      console.error('Failed to load products', error);
      this.loading = false;
    });
  }
}
