import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginModel } from '../features/login/login-component/login-model';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserAuthService {
  private apiUrl = 'http://localhost:5201/api/users/login';

  constructor(private http: HttpClient) {}

  loginUser(loginRequest: LoginModel): Observable<LoginModel>{
    console.log('Server making a login request to the http client', this.apiUrl);
    return this.http.post<LoginModel>(this.apiUrl, loginRequest).pipe(
      tap( data => {(console.log('Data received from the api', loginRequest));
      })
    );
  }
}
