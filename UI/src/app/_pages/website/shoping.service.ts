import { ToastrService } from 'ngx-toastr';
import { Accounts, Catalog, Order } from '../../_models/models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { Product } from 'src/app/_models/models';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})

export class ShopingService {
  products: Product[] = [];

  constructor(
    private http: HttpClient,
    private _toast: ToastrService

  ) { }


  catalog(searchText: string): Observable<Catalog> {
    searchText = searchText == null ? "" : searchText;
    return this.http.get<Catalog>(`${environment.apiUrl + environment.version}/product?searchText=` + searchText);
  }

  accounts(): Observable<Accounts> {
    return this.http.get<Accounts>(`${environment.apiUrl + environment.version}/account/get`);
  }

  getAllOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${environment.apiUrl + environment.version}/order/get/`)
      .pipe(
        catchError(this.handleError)
      );
  }

  order(order: Order) {
    return this.http.post<string>(`${environment.apiUrl + environment.version}/order/save/`, order)
      .pipe(map(resp => {
        return resp;
      }));
  }



  private handleError(err: any) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

}
