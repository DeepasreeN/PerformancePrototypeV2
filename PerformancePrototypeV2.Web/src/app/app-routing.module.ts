import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TransactionComponent } from './transaction/transaction.component';
import { AppComponent } from './app.component';

const routes: Routes = [  
    {path: '', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
    {path: 'home', component: AppComponent} ,
    {path: 'transaction', component: TransactionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
