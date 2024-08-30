import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { TransactionComponent } from './transaction.component';
import { provideHttpClient } from '@angular/common/http';

import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [
    TransactionComponent
  ],
  imports: [
    BrowserModule,
    TableModule,
    BrowserAnimationsModule
  ],
  providers: [provideHttpClient()],
  exports: [
    TransactionComponent
  ]
})
export class TransactionModule { }
