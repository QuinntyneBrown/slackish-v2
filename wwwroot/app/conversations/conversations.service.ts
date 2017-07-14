import {Injectable} from "@angular/core";
import {SecuredHttpService} from "../shared/services/http.service";

@Injectable()
export class ConversationsService {
    constructor(private _http: SecuredHttpService) { }

    public getByCurrentProfile() {
        return this._http.get("/api/conversations/getByCurrentProfile");
    }
}
