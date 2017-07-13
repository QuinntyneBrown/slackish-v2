import { Routes, RouterModule } from '@angular/router';
import { ConversationComponent } from "../conversations";

export const routes: Routes = [
    {
        path: '',
        component: ConversationComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    ConversationComponent
];