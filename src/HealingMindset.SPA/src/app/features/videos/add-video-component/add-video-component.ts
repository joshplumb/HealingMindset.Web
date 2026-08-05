import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { VideoService } from '../../../services/video.service';
import { VideoModel } from '../../../models/video-model';

@Component({
  selector: 'app-add-video-component',
  imports: [ReactiveFormsModule],
  templateUrl: './add-video-component.html',
  styleUrl: './add-video-component.css',
})
export class AddVideoComponent {

  private videoService = inject(VideoService);

  isSubmitting = false;
  errorMessage?: string;

  addVideoForm = new FormGroup({
    title: new FormControl('', Validators.required),
    youtubeId: new FormControl('', Validators.required),
    description: new FormControl('')
  });

  onSubmitAddVideo(){
    const vidModel: VideoModel = this.addVideoForm.value as VideoModel;
    this.isSubmitting = true;
    this.errorMessage = undefined;

    this.videoService.createVideo(vidModel)
    .subscribe({
      next:() => {},
      error:() => { this.errorMessage = 'Video not added'; },
      complete:() => { this.isSubmitting = false; }
    });
  }
}
