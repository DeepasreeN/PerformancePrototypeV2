import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Performance Prototype APP V2';
  showComponent:boolean = false;
  toggleComponent(){
      this.showComponent = !this.showComponent;
  }
}
