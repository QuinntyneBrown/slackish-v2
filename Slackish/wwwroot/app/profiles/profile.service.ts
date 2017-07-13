import {Injectable}  from "@angular/core";
import {SecuredHttpService} from "../shared/http.service";


@Injectable()
export class ProfilesService {
    constructor(private _http: SecuredHttpService) { }
    
    public getOtherProfiles() {
        return this._http.get("/api/profiles/getOtherProfiles");
    }    
}
