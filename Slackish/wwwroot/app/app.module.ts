import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';

import {ConversationsModule} from "../app/conversations";
import {MessagesModule} from "../app/messages";
import {ProfilesModule} from "../app/profiles";
import {SharedModule} from "../app/shared";

import { AppComponent } from './app.component';

import {
    RoutingModule,
    routedComponents
} from "./routing";

const declarables = [
    AppComponent,
    routedComponents
];

const providers = [

];

@NgModule({
    imports: [
        RoutingModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        RouterModule,

        ConversationsModule,
        MessagesModule,
        ProfilesModule,
        SharedModule
    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

