import { Component, inject } from '@angular/core';
import { FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { UserAuthService } from '../../services/user-auth.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-login-logout-component',
  imports: [ReactiveFormsModule, AsyncPipe],
  templateUrl: './login-logout-component.html',
  styleUrl: './login-logout-component.css',
})

export class LoginLogoutComponent {

  private authService = inject(UserAuthService);
  _currentUserSubject = this.authService.currentUserSubject;

  isSubmitting = false;
  errorMessage?: string;

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  onSubmitLogin() {
    if (this.loginForm.invalid || this.isSubmitting) return;

    const {email, password} = this.loginForm.value;
    this.isSubmitting = true;
    this.errorMessage = undefined;

    this.authService.loginUser(email as string, password as string)
      .subscribe({
        next: () => { /* optionally navigate; auth state should update in service */ },
        error: () => { this.errorMessage = 'Login failed'; },
        complete: () => { this.isSubmitting = false; }
      });
  }

  onSubmitLogout(){
    if(this._currentUserSubject.value !== null){
      this.authService.logoutUser();
    }
    else{
      return;
    }
  }
}
