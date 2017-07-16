import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {RouterModule} from "@angular/router";

import {AuthGuardService} from "./services/auth-guard.service"
import {AuthenticationService} from "./services/authentication.service";
import {HttpService, SecuredHttpService} from "./services/http.service";
import {LoginRedirectService} from "./services/login-redirect.service";
import {SignalRMessageQueueFactory} from "./services/signalr-message-queue-factory";
import {Storage} from "./services/storage.service";

import {DotsMenuComponent} from "./components/dots-menu.component";
import {HeaderComponent} from "./components/header.component";
import {PopoverComponent} from "./components/popover.component";

import {MasterPageLayoutComponent} from "./layout/master-page-layout.component";

const providers = [
    HttpService,
    SecuredHttpService,
    SignalRMessageQueueFactory,
    AuthGuardService,
    AuthenticationService,
    LoginRedirectService,
    Storage
];

const declarables = [
    DotsMenuComponent,
    HeaderComponent,
    PopoverComponent,

    MasterPageLayoutComponent
];

@NgModule({
    imports: [CommonModule, RouterModule],
    entryComponents: [PopoverComponent],
    declarations: [declarables],
    exports:[declarables],
    providers: providers
})
export class SharedModule {}