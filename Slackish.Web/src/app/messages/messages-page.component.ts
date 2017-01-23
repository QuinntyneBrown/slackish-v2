import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./messages-page.component.html"),
    styles: [require("./messages-page.component.scss")],
    selector: "messages-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MessagesPageComponent implements OnInit { 
    ngOnInit() {

    }
}
