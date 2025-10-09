import { Routes } from '@angular/router';
import { LayoutComponent } from '@/presentation/components/layout/layout.component';
import { NotfoundPage } from '@/presentation/pages/notfound/notfound.page';
import { HomePage } from '@/presentation/pages/home/home.page';

export const appRoutes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [{ path: '', component: HomePage }]
    },
    { path: 'auth', loadChildren: () => import('./app/features/auth/auth.routes') },
    { path: 'notfound', component: NotfoundPage },
    { path: '**', redirectTo: '/notfound' }
];
