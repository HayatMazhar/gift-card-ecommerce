import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/_services/data.service';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent implements OnInit {
  form!: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private _dataService: DataService
  ) {

   }

  ngOnInit(): void {
    this.form = this.formBuilder.group(
      {
        searchText: ["", Validators.required],
      },
  );
  }
  get f() {
    return this.form.controls;
  }

  onSearchChange(val: any) {
      this._dataService.setData(val.target.value);
  }
}
