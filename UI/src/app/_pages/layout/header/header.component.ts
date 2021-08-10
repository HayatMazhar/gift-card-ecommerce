import { ShopingService } from './../../website/shoping.service';
import {  ShoppingItem } from 'src/app/_models/models';
import { Component, OnInit, EventEmitter, Input } from '@angular/core';
import { Router} from '@angular/router';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/_store/app-state';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() count! : number;
  shoppingItems$!: Observable<ShoppingItem[]>;

  constructor(
    private store: Store<AppState>,
    public _service: ShopingService,
    private readonly router: Router,

    ) {}

    ngOnInit(): void {
      this.shoppingItems$ = this.store.select(store => store.shopping);
    }

}
