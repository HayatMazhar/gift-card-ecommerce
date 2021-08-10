import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { BannerComponent } from './banner/banner.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    FooterComponent,
    HeaderComponent,
    BannerComponent,
  ],
  declarations: [
    FooterComponent,
    HeaderComponent,
    BannerComponent,
  ]
})
export class LayoutModule { }
