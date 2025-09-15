import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { PrimeNG } from 'primeng/config';
import { ToastModule } from 'primeng/toast';
import { MyPreset } from './primeng/presets/primary.preset';


@Component({
  selector: 'app-root',
  imports: [
    CommonModule,
    RouterModule,
    RouterOutlet,
    ToastModule,
    ButtonModule
  ],
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'boilerplate-spa';

  constructor(
    private readonly primeng: PrimeNG
  ) {

    this.primeng.theme.set({
      preset: MyPreset,
      options: {
        darkModeSelector: false,
        cssLayer: {
          name: 'primeng',
          order: 'tailwind-base, primeng, tailwind-utilities'
        }
      }
    })
  }


}
