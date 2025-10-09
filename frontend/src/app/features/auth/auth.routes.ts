import { Routes } from '@angular/router';
import { AccessPage } from './pages/access.page';
import { LoginPage } from './pages/login.page';
import { ErrorPage } from './pages/error.page';

export default [
    { path: 'access', component: AccessPage },
    { path: 'error', component: ErrorPage },
    { path: 'login', component: LoginPage }
] as Routes;
