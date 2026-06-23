import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class VideoService {
  private apiUrl = 'http://localhost:5201/api/videos'; // Your Web API endpoint

  constructor(private http: HttpClient) {}

  getVideos(): Observable<any[]>{
    console.log('Server making a request to the http client', this.apiUrl);
    return this.http.get<any[]>(this.apiUrl).pipe(
      tap( data => {(console.log('Data received from API', data));
      })
    );
  }
}
