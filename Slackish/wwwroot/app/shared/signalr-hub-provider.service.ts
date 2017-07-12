import { Observable } from "rxjs";

export class SignalRHubProviderService {
    private _hubs: any;

    public select(options: { hubName: string, methodName: string }): Observable<any> {
        return new Observable((subscriber) => {
            if (this._connectionReady) {
                this._hubs[options.hubName].on(options.methodName, value => {
                    subscriber.next(value);
                });
            } else {
                this._connection.start().done(() => {
                    this._connectionReady = true;
                    this._hubs[options.hubName].on(options.methodName, value => {
                        subscriber.next(value);
                    });
                });
            }             
        });        
    }

    public messages$: Observable<any> = this.select({ hubName: "messageHub", methodName: "messages" });

    private _connection: any;

    private _connectionReady: boolean;
    
}