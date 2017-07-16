import {Component, ElementRef} from "@angular/core";

@Component({
    templateUrl: "./dots-menu.component.html",
    styleUrls: ["./dots-menu.component.css"],
    selector: "ce-dots-menu",
})
export class DotsMenuComponent {
    constructor(private _elementRef:ElementRef) {

    }

    ngAfterViewInit() {
        this._elementRef.nativeElement.style.height = `${0.6875 * Number(this._elementRef.nativeElement.offsetWidth)}px`;
    }

}
