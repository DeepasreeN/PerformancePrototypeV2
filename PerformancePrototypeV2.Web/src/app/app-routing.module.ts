import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { TransactionComponent } from './transaction/transaction.component';
import { AppComponent } from './app.component';

const routes: Routes = [  
    {path: '', component: LoginComponent} ,
    {path: 'home', component: AppComponent} ,
    {path: 'transaction', component: TransactionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
