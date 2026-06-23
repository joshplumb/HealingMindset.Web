import { Component } from '@angular/core';
import { VideoComponent } from '../../videos/video-component/video-component';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-home-component',
  imports: [VideoComponent, RouterLink],
  templateUrl: './home-component.html',
  styleUrl: './home-component.css',
})
export class HomeComponent {

  
}
