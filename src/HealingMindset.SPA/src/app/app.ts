import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLinkActive, RouterLink } from '@angular/router';
import { UserAuthService } from './services/user-auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('HealingMindset.SPA');

  isLoggedIn$;

  constructor(private authService : UserAuthService){
    this.isLoggedIn$ = this.authService.currentUserStatus$
  }

}
