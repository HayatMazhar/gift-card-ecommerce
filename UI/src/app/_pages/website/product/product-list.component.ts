import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Catalog, Product, ShoppingItem } from 'src/app/_models/models';
import { AppState } from 'src/app/_store/app-state';
import { AddItemAction } from 'src/app/_store/shopping.actions';
import { ShopingService } from '../shoping.service';
import { v4 as uuid } from 'uuid';
import { NgxUiLoaderService } from 'ngx-ui-loader';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
  products!: Product[]
  name!: string;
  constructor(
    private route: ActivatedRoute,
    private _service: ShopingService,
    private store: Store<AppState>,
    private ngxService: NgxUiLoaderService

  ) { }

  ngOnInit() {
    this.getAll();
  }


  getAll() {
    this.ngxService.start();
    let id = this.route.snapshot.queryParams.Id;
    this._service
      .catalog("")
      .subscribe((response: Catalog) => {
        this.name = response.brands[id].name;
        this.products =response.brands[id].products;
        this.ngxService.stop();

      });
  }

  addToCart(selectedProduct: Product): void {
    const newShoppingItem = {
      id: uuid(),
      quantity: 1,
      price: selectedProduct.price.max,
      product: selectedProduct
    } as ShoppingItem;
    this.store.dispatch(new AddItemAction(newShoppingItem));
  }
}
