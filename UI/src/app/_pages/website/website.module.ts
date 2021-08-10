import { NgxUiLoaderConfig, NgxUiLoaderModule } from 'ngx-ui-loader';
import { OrderListComponent } from './order/order-list.component';
import { CatalogComponent } from './catalog/catalog.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutModule } from '../layout/layout.module';
import { TruncatePipe } from 'src/app/_controls/pipes/truncate.pipe';
import { ProductListComponent } from './product/product-list.component';
import { CartDetailComponent } from './cart/cart-detail.component';
import { FormsModule } from '@angular/forms';
import { AccountComponent } from './accounts/account.component';

const routes: Routes = [

  { path: '', component: CatalogComponent },
  { path: 'catalog', component: CatalogComponent },
  { path: 'products', component: ProductListComponent},
  { path: 'cart-detail', component: CartDetailComponent },
  { path: 'accounts', component: AccountComponent },
  { path: 'order-history', component: OrderListComponent },

];

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    LayoutModule,
    NgxUiLoaderModule,
    RouterModule.forChild(routes),
  ],
  declarations: [
    CatalogComponent,
    AccountComponent,
    ProductListComponent,
    CartDetailComponent,
    OrderListComponent,
    TruncatePipe,
    ],


  exports: [
    RouterModule
]

})
export class WebsiteModule { }
