import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class UserAuthService {
  private apiLoginUrl = 'http://localhost:5201/api/users/login';
  private apiLogoutUrl = 'http://localhost:5201/api/users/logout';

  public currentUserSubject$ = new BehaviorSubject<any | null>(null);
  public currentUser$: Observable<any | null> = this.currentUserSubject$.asObservable();

  constructor(private http: HttpClient) {}

  me(): Observable<User>{
    return this.http.get<User>
  }

  loginUser(email: string, password: string): Observable<User>{
    console.log('Server making a login request to the http client', this.apiLoginUrl);
    return this.http.post<User>(this.apiLoginUrl, {email, password}).pipe(
      tap(data => {
          (console.log('Data received from the api for', {email}));
          this.currentUserSubject$.next(data);
      })
    );
  }
  
  logoutUser(): Observable<User>{
    console.log('Loggin out via', this.apiLogoutUrl);
    return this.http.post<User>(this.apiLogoutUrl, null).pipe(
      tap(data => {
        [console.log('Data received from the api')];
        this.currentUserSubject$.next(null);
      })
    )
  }
}
