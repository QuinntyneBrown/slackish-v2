import {Injectable} from "@angular/core";
import {
    CanActivate,
    CanActivateChild,
    CanLoad,
    Route,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import {Storage} from "./storage.service";
import {LoginRedirectService} from "./login-redirect.service";
import {Observable} from "rxjs";
import {constants} from "./constants";

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(
        private _storage: Storage,
        private _loginRedirectService: LoginRedirectService
    ) { }

    public canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> {
        const token = this._storage.get({ name: constants.ACCESS_TOKEN_KEY });

        if (token)
            return Observable.of(true);

        this._loginRedirectService.lastPath = state.url;
        this._loginRedirectService.redirectToLogin();

        return Observable.of(false);       
    }
}