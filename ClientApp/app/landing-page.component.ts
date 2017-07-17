/// <reference path="shared/constants.ts" />
import { Component, Input, OnInit, ViewEncapsulation } from "@angular/core";

@Component({
    templateUrl: "./landing-page.component.html",
    styleUrls: [
        "./shared/styles/page.css",
        "./landing-page.component.css"
    ],
    selector: "ce-landing-page",
    encapsulation: ViewEncapsulation.Emulated
})
export class LandingPageComponent { }
