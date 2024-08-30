import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GlobalVariables } from './globalvariables';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = GlobalVariables.apiUrl;

  constructor(private http: HttpClient) { }

  login(credentials: { email: string, password: string }): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(this.apiUrl+'/Login', credentials, { headers });
  }
}
