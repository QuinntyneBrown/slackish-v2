import { Routes, RouterModule } from '@angular/router';

import {
    LandingPageComponent
} from "../landing";

import {
    LoginPageComponent
} from "../profiles";

export const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent,
    },
    {
        path: 'login',
        component: LoginPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    LandingPageComponent,
    LoginPageComponent
];