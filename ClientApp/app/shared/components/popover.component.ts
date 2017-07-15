import { Component, Input, OnInit, ViewEncapsulation, ElementRef } from "@angular/core";
import { LogOutClicked } from "../events";

@Component({
    templateUrl: "./popover.component.html",
    styleUrls: ["./popover.component.css"],
    selector: "ce-popover",
    encapsulation: ViewEncapsulation.Emulated
})
export class PopoverComponent {

    constructor(private _elementRef: ElementRef) {}

    public logoutClicked() {
        alert("?");
        this._elementRef.nativeElement.dispatch(new LogOutClicked());        
    }
}
