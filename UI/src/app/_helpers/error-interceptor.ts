import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { ToastrService } from "ngx-toastr";
import { Router } from "@angular/router";
import { NgxUiLoaderService } from "ngx-ui-loader";


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private _router: Router, private toastr: ToastrService,private ngxService: NgxUiLoaderService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMessage = this.handleError(error);
          this.toastr.error(errorMessage, "Error");
          return throwError(error);
        })
      )
  }

  private handleError = (error: HttpErrorResponse): any => {
    this.ngxService.stopAll();

    switch (error.status) {
      case 0:
        return "Check your internet connection";
      case 400:
        return this.handleBadRequest(error);
      case 404:
        return this.handleNotFound(error);
      case 500:
        return "Something went wrong, Please try again"
      case 900:
        this._router.navigate(['/login']);
        break;

      default:
        break;
    }

  }

  private handleNotFound = (error: HttpErrorResponse): string => {
    this._router.navigate(['/404']);
    return error.message;
  }

  private handleBadRequest = (error: HttpErrorResponse): string => {
      let message = '';
      const values = Object.values(error.error.ValidationErrors);
      values.map((m: any) => {
        message += m + '<br>';
      })

      return message.slice(0, -4);
  }

}
