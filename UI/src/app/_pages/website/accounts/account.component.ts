import { Account, Accounts } from '../../../_models/models';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/_store/app-state';
import { ShopingService } from '../shoping.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';


@Component({
    selector: 'app-account',
    templateUrl: './account.component.html'
})
export class AccountComponent implements OnInit {
  accounts!: Account[];

  constructor(private store: Store<AppState>,
                public router: Router,
                private _service: ShopingService,
                private ngxService: NgxUiLoaderService

    ) { }

    ngOnInit() {
    this.ngxService.start();
    this.getAccountd();
    }

    getAccountd() {
      this._service
      .accounts()
      .subscribe((response: Accounts) => {
        this.accounts = response.accounts;
        localStorage.setItem('account',JSON.stringify(response.accounts.filter(x=>x.isActive == true)[0]?.id));
        this.ngxService.stop();
      });
    }
  }
