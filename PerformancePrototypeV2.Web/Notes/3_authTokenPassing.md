To use an authorization token in server calls in Angular, you typically add the token to the HTTP request headers. This is commonly done using Angular's `HttpClient` and `HttpInterceptor` to automatically attach the token to outgoing requests. Here's how you can do it:

### Step 1: Obtain the Authorization Token
First, you need to obtain the token, usually after a user logs in. This token is typically stored in local storage, session storage, or a service.

```typescript
// Example: Store token in local storage
localStorage.setItem('authToken', 'your-jwt-token');
```

### Step 2: Create an `HttpInterceptor`
Angular’s `HttpInterceptor` allows you to intercept and modify HTTP requests before they are sent to the server.

1. **Generate the interceptor**:
   ```bash
   ng generate service auth-interceptor
   ```

2. **Implement the interceptor**:

   ```typescript
   // auth-interceptor.service.ts
   import { Injectable } from '@angular/core';
   import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
   import { Observable } from 'rxjs';

   @Injectable()
   export class AuthInterceptorService implements HttpInterceptor {
     intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       const authToken = localStorage.getItem('authToken');
       
       // Clone the request and add the authorization header
       const authReq = req.clone({
         setHeaders: {
           Authorization: `Bearer ${authToken}`
         }
       });

       // Pass the modified request to the next handler
       return next.handle(authReq);
     }
   }
   ```

### Step 3: Provide the `HttpInterceptor` in your App Module
You need to add the `HttpInterceptor` to the providers' array in your Angular module.

```typescript
// app.module.ts
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AuthInterceptorService } from './auth-interceptor.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
```

### Step 4: Make HTTP Calls
With the interceptor in place, all HTTP requests made using `HttpClient` will automatically include the authorization token in the headers.

```typescript
// Example of making an HTTP call with HttpClient
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(private http: HttpClient) {}

  getData() {
    this.http.get('https://api.example.com/data').subscribe(data => {
      console.log(data);
    });
  }
}
```

### Explanation
- **Interceptor**: The `AuthInterceptorService` intercepts all outgoing HTTP requests and adds the `Authorization` header with the token.
- **Token Storage**: Tokens are retrieved from local storage (or another storage mechanism) and attached to requests.
- **Global Application**: The interceptor ensures that every HTTP request automatically includes the token without modifying individual service methods.

This setup helps in managing the token securely and consistently across all API calls in your Angular application.