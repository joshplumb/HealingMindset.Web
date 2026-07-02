import { Component } from '@angular/core';
import { FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { UserAuthService } from '../../../services/user-auth.service';

@Component({
  selector: 'app-login-component',
  imports: [ReactiveFormsModule],
  templateUrl: './login-logout-component.css',
  styleUrl: './login-logout-component.css',
})
export class LoginLogoutComponent {

isSubmitting = false;
errorMessage?: string; 

constructor(private authService: UserAuthService) {}

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  onSubmit(){
    if(this.loginForm.invalid || this.isSubmitting) return;

    this.isSubmitting = true;
    this.errorMessage = undefined;

    this.authService.loginUser(this.loginForm.value as { email: string; password: string })
      .subscribe({
        next: () => { /* optionally navigate; auth state should update in service */ },
        error: () => { this.errorMessage = 'Login failed'; },
        complete: () => { this.isSubmitting = false; }
      });
  }
}
