import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Order } from '../_models/models';


@Injectable({ providedIn: 'root' })
export class OrderService {
    private url = 'api/order';
    private httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    private httpOptions = { headers: this.httpHeaders };

    constructor(private httpClient: HttpClient) { }

    getAll(): Observable<Order[]> {
        return this.httpClient.get<Order[]>(`${environment.apiUrl+ environment.version}/order/get/`)
            .pipe(
                catchError(this.handleError)
            );
    }

    order(order: Order) {
      return this.httpClient.post<string>(`${environment.apiUrl+ environment.version}/order/save/`, order)
          .pipe(map(resp => {
              return resp;
          }));
  }


    getWithId(id: number): Observable<Order> {
        const url = `${this.url}/${id}`;
        return this.httpClient.get<Order>(url)
            .pipe(
                catchError(this.handleError)
            );
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
