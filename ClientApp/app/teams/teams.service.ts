import {Injectable} from "@angular/core";
import {SecuredHttpService} from "../shared/services/http.service";
import {Observable} from "rxjs";

@Injectable()
export class TeamsService {
    constructor(private _http: SecuredHttpService) { }

    public getCurrentTeam() {
        return this._http.get("/api/teams/getCurrentTeam");
    }

    public setCurrentTeam(options: {teamName:string}) {
        return this._http.post("/api/teams/getCurrentTeam", options);
    }

    public get() {
        return this._http.get("/api/teams/get");
    }
}
