import {Injectable} from "@angular/core";
import {HttpService} from "./http.service";
import {Observable} from "rxjs";
import {constants} from "./constants";
import {Storage} from "./storage.service";

@Injectable()
export class AuthenticationService {
    constructor(private _httpService: HttpService, private _storage: Storage) { }  

    public tryToLogin(options: any) {
        Object.assign(options, { grant_type: "password" });
        return this._httpService.postFormEncoded("/api/user/token", options)
            .map(response => {
                var accessToken = response.json()["access_token"];
                this._storage.put({ name: constants.ACCESS_TOKEN_KEY, value: accessToken });
                return accessToken;
            })
            .catch(err => {
                return Observable.of(false);
            });
    }
}