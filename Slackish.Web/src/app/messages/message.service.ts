import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Message } from "./message.model";
import { Observable } from "rxjs";
import { environment } from "../environment";

@Injectable()
export class MessageService {
    constructor(private _http: Http) { }

    public add(entity: Message) {
        return this._http
            .post(`${this._baseUrl}/api/message/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/message/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/message/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/message/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return environment.baseUrl; }

}
