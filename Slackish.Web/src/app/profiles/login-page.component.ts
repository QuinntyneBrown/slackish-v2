import { Component, ChangeDetectionStrategy, Input } from "@angular/core";

@Component({
    template: require("./login-page.component.html"),
    styles: [require("./login-page.component.scss")],
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
