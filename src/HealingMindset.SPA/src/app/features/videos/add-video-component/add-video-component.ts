import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { VideoService } from '../../../services/video.service';
import { VideoModel } from '../../../models/video-model';
import { extractYoutubeId } from '../../../utils/youtube.utils';

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
    const formValues = this.addVideoForm.value;

    const vidModel: VideoModel = {
      ... formValues, 
      youtubeId: extractYoutubeId(formValues.youtubeId ?? '')
    } as VideoModel

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
