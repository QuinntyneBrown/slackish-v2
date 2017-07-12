import {Observable} from "rxjs";
import {NgZone} from "@angular/core";
import {SignalRHubProviderService} from "../shared/signalr-hub-provider.service";

export class ConversationStreamService {   

    private readonly _hub: any;

    constructor(private _signalRHubProviderService: SignalRHubProviderService) {
        
    }
}