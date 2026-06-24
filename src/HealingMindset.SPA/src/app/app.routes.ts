import { Routes } from '@angular/router';
import { VideoComponent } from './features/videos/video-component/video-component';
import { HomeComponent } from './features/home/home-component/home-component';
import { RegisterComponent } from './features/register/register-component/register-component';
import { LoginComponent } from './features/login/login-component/login-component';
import { AddVideoComponent } from './features/videos/add-video-component/add-video-component';
import { PodcastComponent } from './features/podcasts/podcast-component/podcast-component';

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
    },
    {
        path: 'login-component',
        component: LoginComponent,
        title: 'login-component'
    },
    {
        path: 'register-component',
        component: RegisterComponent,
        title: 'register-component'
    },
    {
        path: 'add-video-component',
        component: AddVideoComponent,
        title: 'add-video-component'
    },
    {
        path: 'podcast-component',
        component: PodcastComponent,
        title: 'podcast-component'
    }
];
