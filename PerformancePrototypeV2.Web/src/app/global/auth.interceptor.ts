import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GlobalVariables } from './globalvariables';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
private loginUrl = GlobalVariables.apiUrl+'/login';
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log("Interceptor");
    if (req.url.includes(this.loginUrl)) {
        return next.handle(req);
      }
    const token = localStorage.getItem('authToken');
    if (token) {
      const authReq = req.clone({
        headers: req.headers.set('Authorization', `Bearer ${token}`)
      });
    
      return next.handle(authReq);
    } else {
      return next.handle(req);
    }
  }
}