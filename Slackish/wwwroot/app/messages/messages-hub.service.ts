import {BehaviorSubject} from "rxjs";
import {NgZone} from "@angular/core";
import {SignalR} from "../shared/signalr-connection.service";

declare var $: any;

export class MessagesHubService extends BehaviorSubject<any> {
    private _hub: any;

    constructor(private _zone: NgZone, private _signalRConnectionService: SignalR) {
        super(null);
        const connection = ($ as any).hubConnection("/");
        this._hub = connection.createHubProxy("messagesHub");
        connection.start().done(() => {
            
        });
    }
}