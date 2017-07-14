import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";

import {AuthGuardService} from "./services/auth-guard.service"
import {AuthenticationService} from "./services/authentication.service";
import {HttpService, SecuredHttpService} from "./services/http.service";
import {LoginRedirectService} from "./services/login-redirect.service";
import {SignalRMessageQueueFactory} from "./services/signalr-message-queue-factory";
import {Storage} from "./services/storage.service";

import {PopoverComponent} from "./components/popover.component";

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
export class SharedModule {}