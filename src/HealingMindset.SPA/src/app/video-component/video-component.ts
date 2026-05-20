import { Component, OnInit } from '@angular/core';
import { YouTubePlayer } from '@angular/youtube-player';
import { VideoService } from '../services/video.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-video-component',
  imports: [YouTubePlayer, AsyncPipe, RouterLink],
  templateUrl: './video-component.html',
  styleUrl: './video-component.css',
})
export class VideoComponent {
  videos$: Observable<any[]> | undefined;

  constructor(private videoService: VideoService) {}

  ngOnInit(): void {
    this.videos$ = this.videoService.getVideos().pipe
    (tap(data=> console.log('Data flowing through pipe', data)));
  }
}
