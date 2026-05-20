import { Routes } from '@angular/router';
import { VideoComponent } from './video-component/video-component';
import { HomeComponent } from './home-component/home-component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        title: 'home-component'
    },
    {
        path: 'video-component',
        component: VideoComponent,
        title: 'video-component'
    }
];
