import {Component} from "@angular/core";
import {AuthenticationService, LoginRedirectService} from "../shared";

@Component({
    templateUrl: "./login-page.component.html",
    styleUrls: ["./login-page.component.css"],
    selector: "ce-login-page"
})
export class LoginPageComponent {
    constructor(
        private _authenticationService: AuthenticationService,
        private _loginRedirectService: LoginRedirectService) { }

    public tryToLogin() {

    }
}
