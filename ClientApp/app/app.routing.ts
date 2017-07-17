import {Routes, RouterModule} from '@angular/router';
import {ConversationPageComponent} from "./conversations";
import {AuthGuardService} from "./shared";
import {LoginPageComponent} from "./profiles";
import {DiscoverTeamPageComponent} from "./teams";
import {LandingPageComponent} from "./landing-page.component";
import {CreateTeamPageComponent} from "./teams/create-team-page.component";

export const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent
    },
    {
        path: 'conversations',
        component: ConversationPageComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: 'login',
        component: LoginPageComponent
    },
    {
        path: 'teams/discover',
        component: DiscoverTeamPageComponent
    },
    {
        path: 'teams/:teamName',
        component: LoginPageComponent
    },
    {
        path: 'teams/create',
        component: CreateTeamPageComponent
    }

];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    ConversationPageComponent,
    DiscoverTeamPageComponent,
    LandingPageComponent,
    LoginPageComponent    
];