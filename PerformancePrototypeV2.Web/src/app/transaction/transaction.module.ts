import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { TransactionComponent } from './transaction.component';
import { provideHttpClient } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from '../global/auth.interceptor';

import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    TransactionComponent
  ],
  imports: [
    BrowserModule,
    TableModule,
    ButtonModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [provideHttpClient(),{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  exports: [
    TransactionComponent
  ]
})
export class TransactionModule { }
