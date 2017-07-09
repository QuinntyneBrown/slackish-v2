import { BehaviorSubject } from "rxjs";

declare var $: any;

export class ProfilesHubService extends BehaviorSubject<any> {
    private _hub: any;

    constructor() {
        super(null);
        const connection = ($ as any).hubConnection("/");
        this._hub = connection.createHubProxy("profilesHub");
        connection.start().done(() => {
            
        });
    }
}