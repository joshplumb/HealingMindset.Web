import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, catchError, Observable, of } from 'rxjs';
import { tap } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class UserAuthService {
  private apiBaseAuthUrl = 'https://localhost:7238/api/users';

  private currentUserSubject$ = new BehaviorSubject<User | null>(null);
  public currentUser$ = this.currentUserSubject$.asObservable();

  constructor(private http: HttpClient) {
    this.fetchCurrentUser().subscribe();
  }

  fetchCurrentUser(): Observable<User | null>{
    console.log('Server making a fetch request for the current user', '${this.apiBaseAuthUrl}/current');
    return this.http.get<User>(`${this.apiBaseAuthUrl}/current`, {withCredentials:true}).pipe(
      tap(user =>{
        (console.log('Current user has been retreived', user));
        this.currentUserSubject$.next(user);
      }), catchError(err => {
        this.currentUserSubject$.next(null);
        return of(null);
      })
    );
  }

  loginUser(email: string, password: string): Observable<User>{
    console.log('Server making a login request to the http client', '${this.apiBaseAuthUrl}/login');
    return this.http.post<User>(`${this.apiBaseAuthUrl}/login`, {email, password}, {withCredentials: true})
    .pipe(
      tap(user => {
          (console.log('Data received from the api for', user));
          this.currentUserSubject$.next(user);
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
