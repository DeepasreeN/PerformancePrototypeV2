import { Component } from "@angular/core";
import { TransactionService } from "./transaction.service";
import { Transaction } from "../models/transactions";
import { TableLazyLoadEvent } from "primeng/table";
import { saveAs } from 'file-saver';

@Component({
    selector:'app-transaction',
    templateUrl:'./transaction.component.html',
    styleUrl:'./transaction.component.css'
})

export class TransactionComponent{
    transactions: Transaction[] = [];
    totalRecords:number=0;
    rowsPerPageOptions:number[]=[5,10,15,20];
    loading:boolean=false;
    currentSkipCount :number=0;
  

    constructor(private transactionservice:TransactionService){
    }

  downloadCSV() {
    this.loading=true;
    this.transactionservice.downloadTransactions().subscribe({
      next:(response)=>{
        const a = document.createElement('a');
        const objectUrl = URL.createObjectURL(response);
        a.href = objectUrl;
        a.download = 'data.csv';
        a.click();
        URL.revokeObjectURL(objectUrl);  // Clean up
        this.loading=false;
      },
      error:(error)=>{
        console.error('Error downloading the file', error);
        this.loading=false;
      }
    });
  }

    loadTransactions($event:TableLazyLoadEvent) { 
       // console.log($event);
        this.loading=true;
        this.transactionservice.getTransactionsPerPage($event.rows|| 5,$event.first||0,$event.sortField|| '',$event.sortOrder|| 1)
        .subscribe({
            next:(response) => {
                this.transactions = response.data.transactiondetails;  
                this.totalRecords=response.data.totalcount;
                this.loading=false;        
            },
            error:(error) => {
            console.error('Error fetching transaction data', error);
            this.loading=false;
            }   
        })  
    }  
}