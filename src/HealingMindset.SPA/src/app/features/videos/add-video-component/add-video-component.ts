import { Component, inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { VideoService } from '../../../services/video.service';

@Component({
  selector: 'app-add-video-component',
  imports: [],
  templateUrl: './add-video-component.html',
  styleUrl: './add-video-component.css',
})
export class AddVideoComponent {

  private videoService = inject(VideoService);

  addVideoForm = new FormGroup({
    videoName: new FormControl('', Validators.required),
    videoUrl: new FormControl('', Validators.required),
    videoDescription: new FormControl('')
  });

  onSubmitAddVideo(){
    
  }
}
