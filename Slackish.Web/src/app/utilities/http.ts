export class Http extends XMLHttpRequest {    
    public static pendingRequests = 0;

    public open(method: string, url: string, async: boolean = true, user: string = null, password: string = null) {        
        super.open(method, url, async, user, password);
    }

    public setRequestHeader(header: string, value: string) {
        super.setRequestHeader(header, value);
    }
    
    public set onload(callback:any) {
        super.onload = (ev:Event) => {
            Http.pendingRequests--;

            Http._callbacks.forEach(cb => cb(Http.pendingRequests));
            callback(ev);
        }
    }

    public send(data: any) {
        Http.pendingRequests++;
        Http._callbacks.forEach(cb => cb(Http.pendingRequests));
        super.send(data);
    }

    private static _callbacks: Array<any> = [];

    public static addEventListeners(callback) {
        this._callbacks.push(callback);
    }
}

