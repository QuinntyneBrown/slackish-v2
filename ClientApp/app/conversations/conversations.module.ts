import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {Routes,RouterModule} from "@angular/router";

import {ProfilesModule} from "../profiles";
import {SharedModule} from "../shared"

import {ConversationAboutComponent} from './conversation-about.component';
import {ConversationDetailComponent} from './conversation-detail.component';
import {ConversationHeaderComponent} from './conversation-header.component';
import {ConversationListComponent} from './conversation-list.component';
import {ConversationMessagesComponent} from './conversation-messages.component';
import {ConversationDetailHeaderComponent} from "./conversation-detail-header.component";
import {ConversationListHeaderComponent} from "./conversation-list-header.component";

import {ConversationsService} from "./conversations.service";

const declarables = [
    ConversationAboutComponent,
    ConversationDetailComponent,
    ConversationHeaderComponent,
    ConversationListComponent,
    ConversationMessagesComponent,
    ConversationDetailHeaderComponent,
    ConversationListHeaderComponent
];

const providers = [
    ConversationsService
];

const entryComponents = [
    
];

@NgModule({
    imports: [CommonModule, ProfilesModule, SharedModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers,
    entryComponents: entryComponents
})
export class ConversationsModule {}
