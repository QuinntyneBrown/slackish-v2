import {Injectable} from "@angular/core";
import {SecuredHttpService} from "../shared/services/http.service";
import {Observable} from "rxjs";

@Injectable()
export class TeamsService {
    constructor(private _http: SecuredHttpService) { }

    public getCurrentTeam() {
        return this._http.get("/api/teams/getCurrentTeam");
    }
}
