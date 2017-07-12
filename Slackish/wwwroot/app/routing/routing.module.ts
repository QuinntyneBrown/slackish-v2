import { Routes, RouterModule } from '@angular/router';

import {
    LandingPageComponent
} from "../landing";

export const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    LandingPageComponent
];