import { BehaviorSubject } from "rxjs";

declare var $: any;

export class ConversationsHubService extends BehaviorSubject<any> {
    private _hub: any;

    constructor() {
        super(null);
        const connection = ($ as any).hubConnection("/");
        this._hub = connection.createHubProxy("convesationsHub");
        connection.start().done(() => {
            
        });
    }
}