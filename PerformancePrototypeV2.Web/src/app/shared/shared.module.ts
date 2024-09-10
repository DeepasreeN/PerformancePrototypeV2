import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CapitalizePipe } from './capitalize.pipe';
import { LoaderComponent } from './loader/loader.component';

@NgModule({
  declarations: [
    CapitalizePipe,
    LoaderComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    CapitalizePipe,
    LoaderComponent
  ]
})
export class SharedModule { }
  