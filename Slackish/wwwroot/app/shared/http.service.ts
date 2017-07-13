import {Http} from "@angular/http";
import {Injectable} from "@angular/core";

@Injectable()
export class HttpService {
    constructor(private _http: Http) { }

    public get(): Promise<any> {
        throw new DOMException();
    }

    public post(): Promise<any> {
        throw new DOMException();
    }

    public put(): Promise<any> {
        throw new DOMException();
    }

    public delete(): Promise<any> {
        throw new DOMException();
    }
}

export class SecuredHttpService {
    constructor(private _http: Http) { }

    public get(): Promise<any> {
        throw new DOMException();
    }

    public post(): Promise<any> {
        throw new DOMException();
    }

    public put(): Promise<any> {
        throw new DOMException();
    }

    public delete(): Promise<any> {
        throw new DOMException();
    }
}