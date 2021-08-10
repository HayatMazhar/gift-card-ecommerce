import { ShopingService } from '../shoping.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { APIResponse, Brand, Catalog } from 'src/app/_models/models';
import { DataService } from 'src/app/_services/data.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {
  catalog!: Brand[];

  constructor(
    private _service: ShopingService,
    private _dataService: DataService,
    private readonly router: Router,
    private ngxService: NgxUiLoaderService
  ) {}


  ngOnInit() {
    this.ngxService.start();
    this._dataService.getData().subscribe(searchText => {
    this.getAll(searchText);
  });

  }

  getAll(searchText : string) {
    this._service
      .catalog(searchText)
      .subscribe((response: Catalog) => {
        this.catalog = response.brands;
        this.ngxService.stop();
      });
  }

  productslisting(id: number) {
    let url ="products?Id=" + id
    window.location.href = url;
  }

}
