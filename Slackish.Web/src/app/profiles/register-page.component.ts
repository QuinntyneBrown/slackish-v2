import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./register-page.component.html"),
    styles: [require("./register-page.component.scss")],
    selector: "register-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterPageComponent implements OnInit { 
    ngOnInit() {

    }
}
