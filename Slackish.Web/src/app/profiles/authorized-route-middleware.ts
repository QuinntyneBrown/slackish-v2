import { RouterMiddleware, Router } from "../router";
import { createElement, Storage, TOKEN_KEY, Log } from "../utilities";
import { LoginRedirect } from "./login-redirect";
import { ProfileService } from "./profile.service";
import { CurrentProfile } from "./current-profile";
import { Profile } from "./profile.model";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthorizedRouteMiddleware extends RouterMiddleware {
    constructor(
        private _router: Router,
        private _loginRedirect: LoginRedirect,
        private _storage: Storage,
        private _profileService: ProfileService,
        private _currentProfile: CurrentProfile
    ) {
        super();
    }

    public beforeViewTransition(options: RouteChangeOptions) {     
        
        if (options.nextRoute.authRequired && !this._storage.get({ name: TOKEN_KEY })) {                      
            this._loginRedirect.setLastPath(window.location.pathname);
            options.cancelled = true;
            this._router.navigate(["login"]);                        
        }

        if (options.nextRoute.authRequired)
            this._profileService.getCurrentProfile().then((results: string) => {
                if (results == "") {
                    this._storage.put({ name: TOKEN_KEY, value: null });
                    this._router.navigate(["login"]);
                } else {
                    const profile: Profile = JSON.parse(results) as Profile;
                    this._currentProfile.username = profile.username;
                }
            });
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        return null;
    }

    public afterViewTransition(options: RouteChangeOptions) {

    }

}