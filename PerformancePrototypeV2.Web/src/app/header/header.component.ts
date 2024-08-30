import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
 
  isMenuOpen: boolean = false;
  title = 'Performance Prototype APP V2';
  // Method to toggle the menu:
  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }
}