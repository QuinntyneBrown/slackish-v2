import {Routes, RouterModule} from '@angular/router';
import {ConversationComponent} from "../conversations";
import {AuthGuardService} from "../shared";
import {LoginPageComponent} from "../profiles";

export const routes: Routes = [
    {
        path: '',
        component: ConversationComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: '/login',
        component: LoginPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    ConversationComponent
];