import { Component } from '@angular/core';
import { AuthService } from '../global/auth.service';
import { Router } from '@angular/router';
import { LocalStorageService } from '../global/localstorage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginData = { email: '', password: '' };
  errorMessage: string = '';

  constructor(
    private authService: AuthService, 
    private localStorage:LocalStorageService,
    private router: Router) {}

  onSubmit() {
    this.authService.login(this.loginData).subscribe({
     next:(response) => {
            console.log('Login successful', response);
            this.localStorage.setItem('authToken', response.token);
            this.router.navigate(['/home']);
          },
    error:(error) => {     
            console.error('Login failed', error);
            this.errorMessage = 'Invalid email or password';
        }
    });
  }
}
