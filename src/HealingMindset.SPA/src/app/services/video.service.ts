import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VideoModel } from '../models/video-model';
import { Observable } from 'rxjs';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class VideoService {
  private apiUrl = '/api/videos'; // Your Web API endpoint

  constructor(private http: HttpClient) {}

  getVideos(): Observable<any[]>{
    console.log('Server making a get request for videos to the http client', this.apiUrl);
    return this.http.get<any[]>(this.apiUrl).pipe(
      tap( data => {(console.log('Data received from API', data));
      })
    );
  }
  createVideo(videoRequest : VideoModel): Observable<VideoModel>{
    console.log('Server making a post request to the http client', this.apiUrl);
    return this.http.post<VideoModel>(this.apiUrl, videoRequest, {withCredentials: true}).pipe(
      tap( data => {(console.log('Data received from API', data));
      })
    );
  }
}
