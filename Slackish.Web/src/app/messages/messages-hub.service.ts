import { BehaviorSubject } from "rxjs";

declare var $: any;

export class MessagesHubService extends BehaviorSubject<any> {
    private _hub: any;

    constructor() {
        super(null);
        const connection = ($ as any).hubConnection("/");
        this._hub = connection.createHubProxy("messagesHub");
        connection.start().done(() => {
            
        });
    }
}