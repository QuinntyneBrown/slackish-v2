import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import {HttpService} from "./http.service";
import {SignalR} from "./signalr";

const declarables = [];
const providers = [HttpService,SignalR];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class SharedModule { }
