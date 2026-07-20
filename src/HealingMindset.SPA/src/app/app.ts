import { Component, inject, signal } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { RouterOutlet, RouterLinkActive, RouterLink } from '@angular/router';
import { UserAuthService } from './services/user-auth.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, RouterLinkActive, AsyncPipe],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('HealingMindset.SPA');

  private authService = inject(UserAuthService);

  isLoggedIn$ = this.authService.currentUser$.pipe(
    map(user => user !== null)
    );

  ngOnInit()
  {
    this.authService.fetchCurrentUser();
  }
}