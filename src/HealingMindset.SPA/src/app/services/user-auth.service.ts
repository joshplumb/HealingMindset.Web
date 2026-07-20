import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class UserAuthService {
  private apiBaseAuthUrl = 'http://localhost:5201/api/users';

  public currentUserSubject$ = new BehaviorSubject<any | null>(null);
  public currentUser$: Observable<any | null> = this.currentUserSubject$.asObservable();

  constructor(private http: HttpClient) {}

  fetchCurrentUser(): Observable<User>{
    console.log('Server making a fetch request for the current user', '$this.apiBaseAuthUrl}/current');
    return this.http.get<User>(`${this.apiBaseAuthUrl}/current`, {withCredentials:true}).pipe(
      tap(data =>{
        (console.log('Current user has been retreived'));
      })
    );
  }

  loginUser(email: string, password: string): Observable<User>{
    console.log('Server making a login request to the http client', '${this.apiBaseAuthUrl}/login');
    return this.http.post<User>(`${this.apiBaseAuthUrl}/login`, {email, password}).pipe(
      tap(data => {
          (console.log('Data received from the api for', {email}));
          this.currentUserSubject$.next(data);
      })
    );
  }
  
  logoutUser(): Observable<User>{
    console.log('Loggin out via', `${this.apiBaseAuthUrl}/logout`);
    return this.http.post<User>(`${this.apiBaseAuthUrl}/logout`, null).pipe(
      tap(data => {
        [console.log('Data received from the api')];
        this.currentUserSubject$.next(null);
      })
    )
  }
}
