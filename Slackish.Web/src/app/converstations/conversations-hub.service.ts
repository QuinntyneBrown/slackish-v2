import { BehaviorSubject } from "rxjs";
import { NgZone } from "@angular/core";

declare var $: any;

export class ConversationsHubService extends BehaviorSubject<any> {    
    private _hub: any;

    constructor(private _zone: NgZone) {
        super(null);
        const connection = ($ as any).hubConnection("/");
        this._hub = connection.createHubProxy("convesationsHub");
        connection.start().done(() => {
            
        });
    }
}