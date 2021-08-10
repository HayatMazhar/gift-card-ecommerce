import { ErrorInterceptor } from './_helpers/error-interceptor';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { routing } from './app.routing';
import { LayoutModule } from './_pages/layout/layout.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule, NgbCarouselConfig, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from 'src/environments/environment';
import { ShoppingReducer } from './_store/shopping.reducer';
import { NgxUiLoaderModule } from 'ngx-ui-loader';

@NgModule({

  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    routing,
    LayoutModule,
    NgbModule,
    FontAwesomeModule,
    AngularEditorModule,
    ToastrModule.forRoot(),
    NgxUiLoaderModule,
    StoreModule.forRoot({
      shopping: ShoppingReducer
  }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production })

  ],

  declarations: [
    AppComponent,
  ],

  providers: [
    NgbCarouselConfig,
    NgbModalConfig,
    ToastrService,
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

  ],
  bootstrap: [AppComponent],
  exports: [RouterModule]

})
export class AppModule { }
