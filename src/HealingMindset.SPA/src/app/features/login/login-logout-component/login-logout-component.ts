import { Component } from '@angular/core';
import { FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { UserAuthService } from '../../../services/user-auth.service';

@Component({
  selector: 'app-login-logout-component',
  imports: [ReactiveFormsModule],
  templateUrl: './login-logout-component.html',
  styleUrl: './login-logout-component.css',
})

export class LoginLogoutComponent {

  isLoggedIn$;

  constructor(private authService: UserAuthService) { 
    this.isLoggedIn$ = this.authService.currentUserStatus$;
  }

  isSubmitting = false;
  errorMessage?: string;


  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  onSubmitLogin() {
    if (this.loginForm.invalid || this.isSubmitting) return;

    this.isSubmitting = true;
    this.errorMessage = undefined;

    this.authService.loginUser(this.loginForm.value as { email: string; password: string })
      .subscribe({
        next: () => { /* optionally navigate; auth state should update in service */ },
        error: () => { this.errorMessage = 'Login failed'; },
        complete: () => { this.isSubmitting = false; }
      });
  }
  onSubmitLogout(){
    if(this.isLoggedIn$)
    {
      this.authService.logoutUser()
    }
  }
}
