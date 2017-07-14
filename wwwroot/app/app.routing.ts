import {Routes, RouterModule} from '@angular/router';
import {ConversationPageComponent} from "./conversations";
import {AuthGuardService} from "./shared";
import {LoginPageComponent} from "./profiles";

export const routes: Routes = [
    {
        path: '',
        component: ConversationPageComponent,
        canActivate: [AuthGuardService]
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
    ConversationPageComponent,
    LoginPageComponent
];