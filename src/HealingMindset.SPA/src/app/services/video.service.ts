import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Video } from '../features/videos/video-model';
import { Observable } from 'rxjs';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class VideoService {
  private apiUrl = 'http://localhost:5201/api/videos'; // Your Web API endpoint

  constructor(private http: HttpClient) {}

  getVideos(): Observable<any[]>{
    console.log('Server making a get request to the http client', this.apiUrl);
    return this.http.get<any[]>(this.apiUrl).pipe(
      tap( data => {(console.log('Data received from API', data));
      })
    );
  }
  createVideo(videoRequest : Video): Observable<Video>{
    console.log('Server making a post request to the http client', this.apiUrl);
    return this.http.post<Video>(this.apiUrl, videoRequest).pipe(
      tap( data => {(console.log('Data received from API', data));
      })
    );
  }
}
