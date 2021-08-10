import { ShopingService } from './../shoping.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from 'src/app/_models/models';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html'
})
export class OrderListComponent implements OnInit {
  orders!: Order[];

  constructor(private orderService: ShopingService,
    private ngxService: NgxUiLoaderService
     ) { }

  ngOnInit() {
    this.loadOrders();
  }


  loadOrders(): void {
    this.orderService.getAllOrders()
      .subscribe((response: any) => {
        this.orders = response;

      });
  }
}
