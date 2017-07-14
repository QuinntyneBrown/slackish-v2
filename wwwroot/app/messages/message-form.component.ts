import { Component, Input, OnInit, ViewEncapsulation, Output, EventEmitter } from "@angular/core";

@Component({
    templateUrl: "./message-form.component.html",
    styleUrls: ["./message-form.component.css"],
    selector: "ce-message-form"
})
export class MessageFormComponent {

    @Output()
    public send: EventEmitter<any> = new EventEmitter();
}
