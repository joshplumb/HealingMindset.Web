import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginModel } from '../features/login/login-component/login-model';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserAuthService {
  private apiLoginUrl = 'http://localhost:5201/api/users/login';
  private apiLogoutUrl = 'http://localhost:5201/api/users/logout';

  private currentUserSubject = new BehaviorSubject<any | null>(null);
  public currentUser$: Observable<any | null> = this.currentUserSubject.asObservable();

  constructor(private http: HttpClient) {}

  loginUser(loginRequest: LoginModel): Observable<LoginModel>{
    console.log('Server making a login request to the http client', this.apiLoginUrl);
    return this.http.post<LoginModel>(this.apiLoginUrl, loginRequest).pipe(
      tap(data => {
          (console.log('Data received from the api', loginRequest));
          this.currentUserSubject.next(loginRequest);
      })
    );
  }
  
  logoutUser(): Observable<any>{
    console.log('Loggin out via', this.apiLogoutUrl);
    return this.http.post<any>(this.apiLogoutUrl, null).pipe(
      tap(data => {
        [console.log('Data received from the api')];
        this.currentUserSubject.next(null);
      })
    )
  }
}
