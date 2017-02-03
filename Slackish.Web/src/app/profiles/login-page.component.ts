import { Component, ChangeDetectionStrategy, Input } from "@angular/core";
import { ProfileService } from "./profile.service";

@Component({
    template: require("./login-page.component.html"),
    styles: [require("./login-page.component.scss")],
    selector: "login-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginPageComponent {
    constructor(
        private _profileService: ProfileService
    ) {
    }

    public tryToLogin() {

    }
}
