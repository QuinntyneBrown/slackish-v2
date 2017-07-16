/// <reference path="shared/constants.ts" />
import { Component, Input, OnInit, ViewEncapsulation } from "@angular/core";

@Component({
    templateUrl: "./landing-page.component.html",
    styleUrls: [
        "./shared/styles/page.css",
        "./landing-page.component.css"
    ],
    selector: "cs-landing-page",
    encapsulation: ViewEncapsulation.Native
})
export class LandingPageComponent { }
