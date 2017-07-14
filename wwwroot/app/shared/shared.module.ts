import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";

import {AuthGuardService} from "./auth-guard.service"
import {AuthenticationService} from "./authentication.service";
import {HttpService, SecuredHttpService} from "./http.service";
import {LoginRedirectService} from "./login-redirect.service";
import {SignalRMessageQueueFactory} from "./signalr-message-queue-factory";
import {Storage} from "./storage.service";

import {PopoverComponent} from "./popover.component";

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
    PopoverComponent
];

@NgModule({
    imports: [CommonModule],
    entryComponents: [PopoverComponent],
    declarations: [declarables],
    providers: providers
})
export class SharedModule { }