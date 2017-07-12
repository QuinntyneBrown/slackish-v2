import {Injectable} from "@angular/core";
import {Observable} from "rxjs/Observable";
import {constants} from "./constants";
import {Storage } from "./storage.service";

declare var $: any;

@Injectable()
export class SignalR {
    private _hubs: any;
    private _connection: any;
    private _connectionStarted: boolean;

    constructor(private _storage:Storage) {
        this._connection = this._connection || $.hubConnection(constants.HUB_URL);
        this._connection.qs = { "Bearer": this._storage.get({ name: constants.ACCESS_TOKEN_KEY }) };
        
        this._hubs.messagesHub = this._connection.createHubProxy("messagesHub");
        this._hubs.convesationsHub = this._connection.createHubProxy("conversationsHub");
        
    }

    private _start(): Promise<any> {
        return new Promise( resolve => {
            if (this._connectionStarted) {
                resolve();
            }
            else {
                this._connection.start().done((resolve) => {
                    this._connectionStarted = true;
                    resolve();
                });
            } 
        });
    }

    public messages$() {
        return Observable.fromPromise(this._start())
            .map(() => this._messages$);
    }

    private _messages$: Observable<any> = new Observable((subscriber) => {
        this._hubs.messagesHub.on("messages", value => {
            subscriber.next(value);
        });
    });

}