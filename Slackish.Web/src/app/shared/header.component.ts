import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./header.component.html"),
    styles: [require("./header.component.scss")],
    selector: "app-header",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent implements OnInit { 
    ngOnInit() {

    }
}
