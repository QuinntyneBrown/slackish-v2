import { BehaviorSubject } from "rxjs";
import { NgZone } from "@angular/core";

declare var $: any;

export class MessagesHubService extends BehaviorSubject<any> {
    private _hub: any;

    constructor(private _zone: NgZone) {
        super(null);
        const connection = ($ as any).hubConnection("/");
        this._hub = connection.createHubProxy("messagesHub");
        connection.start().done(() => {
            
        });
    }
}