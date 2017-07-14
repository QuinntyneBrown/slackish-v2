import {Http, RequestOptionsArgs, Headers} from "@angular/http";
import {Injectable} from "@angular/core";
import {constants} from "./constants";
import {Storage} from "./storage.service";
import {Observable} from "rxjs/Observable";

function formEncode(data:any) {
    var pairs = [];
    for (var name in data) {
        pairs.push(encodeURIComponent(name) + '=' + encodeURIComponent(data[name]));
    }
    return pairs.join('&').replace(/%20/g, '+');
}

@Injectable()
export class HttpService {
    constructor(private _http: Http) { }

    public postFormEncoded(url: string, body: any, options?: RequestOptionsArgs) {                
        let headers = new Headers();
        headers.append("Content-Type", "application/x-www-form-urlencoded");
        return this._http.post(url, formEncode(body), { headers: headers });
    }

    public get(url: string): Promise<any> {
        return this._http.get(url, { headers: this._headers })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            })
            .toPromise();
    }

    public post(url: string, body: any): Promise<any> {
        return this._http.post(url, body, { headers: this._headers })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            })
            .toPromise();
    }

    public delete(url: string): Promise<any> {
        return this._http.delete(url, { headers: this._headers })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            })
            .toPromise();
    }

    private get _headers() {
        let headers = new Headers();
        headers.append('Tenant', 'cff89028-3e2d-4997-ab12-a07e0d50ba90');
        return headers;
    }
}

@Injectable()
export class SecuredHttpService {
    constructor(private _http: Http, private _storage: Storage) { }

    public get(url: string): Promise<any> {
        return this._http.get(url, { headers: this.getOAuthHeaders() })
            .map(data => data.json())
            .map(json => json.result.data)
            .catch(err => {
                return Observable.of(false);
            })
            .toPromise();
    }

    public post(url: string, body: any): Promise<any> {
        return this._http.post(url, body, { headers: this.getOAuthHeaders() })
            .map(data => data.json())
            .map(json => json.result.data)
            .catch(err => {
                return Observable.of(false);
            })
            .toPromise();
    }

    public delete(url: string): Promise<any> {
        return this._http.delete(url, { headers: this.getOAuthHeaders() })
            .map(data => data.json())
            .map(json => json.result.data)
            .catch(err => {
                return Observable.of(false);
            })
            .toPromise();
    }

    private getOAuthHeaders() {
        let headers = new Headers();        
        headers.append('Authorization', `Bearer ${this._token}`);
        headers.append('Tenant', 'cff89028-3e2d-4997-ab12-a07e0d50ba90');
        return headers;
    }

    private get _token() { return this._storage.get({ name: constants.ACCESS_TOKEN_KEY }); }
}