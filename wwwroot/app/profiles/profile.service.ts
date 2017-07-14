import {Injectable}  from "@angular/core";
import { SecuredHttpService} from "../shared/services/http.service";

@Injectable()
export class ProfilesService {
    constructor(private _http: SecuredHttpService) { }
    
    public getOtherProfiles():Promise<any> {
        return this._http.get("/api/profiles/getOtherProfiles");
    }   

    public getCurrentProfile(): Promise<any> {        
        return this._http.get("/api/profiles/getCurrentProfile");            
    }
}
