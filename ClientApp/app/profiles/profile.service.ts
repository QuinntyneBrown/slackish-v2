import {Injectable}  from "@angular/core";
import {SecuredHttpService} from "../shared/services/http.service";

@Injectable()
export class ProfilesService {
    constructor(private _http: SecuredHttpService) { }
    
    public getOtherProfiles() {
        return this._http.get("/api/profiles/getOtherProfiles");
    }   

    public getCurrentProfile() {        
        return this._http.get("/api/profiles/getCurrentProfile");            
    }
}
