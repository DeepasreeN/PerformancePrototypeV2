import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class TransactionService {

  private apiUrl = 'http://localhost:5025/api';

  constructor(private http: HttpClient) { }

  getAllTransactions(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Transaction`);
  }
  getTransactionsPerPage(pageSize:number,skipNumber:number,sortField:string |string[],sortOrder:number): Observable<any> {  
    //const{first,rows,sortField,sortOrder}=request;
    //const page=(first/rows)+1;
    let sort= (sortOrder===1)?'asc':'desc';
    let urlParams='pageSize='+ pageSize+'&skipNumber=' + skipNumber;
    if(sortField)
    {
      urlParams+='&sortField='+sortField+'&sortOrder='+sort;
    }
    
    return this.http.get(this.apiUrl+'/Transaction/page?'+urlParams);   
   }  
   getTotalDataCount(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Transaction/count`);
  }
}