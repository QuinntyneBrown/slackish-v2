import { Component, ChangeDetectionStrategy, Input } from "@angular/core";

@Component({
    templateUrl: "./login-page.component.html",
    styleUrls: ["./login-page.component.css"],
    selector: "login-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginPageComponent {
    constructor(
    ) {
    }

    public tryToLogin() {

    }
}
