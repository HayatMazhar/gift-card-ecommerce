import { ShopingService } from './../shoping.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { Order, OrderProduct,  ShoppingItem } from 'src/app/_models/models';
import { AppState } from 'src/app/_store/app-state';
import { DeleteAllItemAction, DeleteItemAction, UpdateItemAction } from 'src/app/_store/shopping.actions';
import { v4 as uuid } from 'uuid';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html'
})
export class CartDetailComponent implements OnInit {
  shoppingItems$!: Observable<ShoppingItem[]>;
  cartSubtotal!: number;
  items!: ShoppingItem[];
  isOrderCreated = false;
  order = { shoppingItem: [] } as any as Order;
  quantities: any[] = [1, 2, 3];

  constructor(private store: Store<AppState>,
    public router: Router,
    private _service: ShopingService,
    private toastr: ToastrService

  ) { }

  ngOnInit() {
    this.shoppingItems$ = this.store.select(store => store.shopping);
    this.calculateSubtotal();
  }

  removeItemFromCart(id: any): void {
    this.store.dispatch(new DeleteItemAction(id));
    this.calculateSubtotal();
  }

  calculateSubtotal(): void {
    this.shoppingItems$.subscribe(x => this.items = x);
    this.cartSubtotal = this.items.reduce((accumulator, currentValue) => accumulator + currentValue.price, 0);
  }

  onQuantityChange(shoppingItem: ShoppingItem) {
    const quantity: number = Number(shoppingItem.quantity);
    shoppingItem.quantity = quantity;
    shoppingItem.price = shoppingItem.product.price.max * Number(quantity);
    this.store.dispatch(new UpdateItemAction(shoppingItem));
    this.calculateSubtotal();
  }

  proceedToCheckout(): void {
    const newOrder = new Order();
    newOrder.requestID = uuid();
    newOrder.accountId = localStorage.getItem('account') ?? "";
    newOrder.products = [];
    this.items.forEach((element) => {
      newOrder.products.push(new OrderProduct(element.product.id.toString(), element.quantity, element.product.minFaceValue));
    });

    this._service
      .order(newOrder)
      .subscribe({
        next: (resp: any) => {
          if (resp.message.length > 20)
            this.toastr.error(resp.message);
          else
            this.toastr.success(resp.message);

        },
        error: (error) => {
        },
      });


  }

  afterOrderCreated(): void {
    this.store.dispatch(new DeleteAllItemAction());
    this.isOrderCreated = true;
    this.router.navigate(['/order-detail', this.order.requestID]);
  }
}
