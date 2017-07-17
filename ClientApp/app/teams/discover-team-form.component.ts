import {
    Component,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    AfterContentInit,
    Renderer,
    ElementRef,
} from "@angular/core";

import {Storage} from "../shared/services/storage.service";
import {constants} from "../shared/constants";
import {Router} from "@angular/router";

import {FormGroup,FormControl,Validators} from "@angular/forms";

@Component({
    templateUrl: "./discover-team-form.component.html",
    styleUrls: [
        "../shared/styles/forms.css",
        "./discover-team-form.component.css"
    ],
    selector: "ce-discover-team-form"
})
export class DiscoverTeamFormComponent {
    constructor() {
        this.tryToDiscover = new EventEmitter();
    }

    @Output()
    public tryToDiscover: EventEmitter<any>;

    public form = new FormGroup({
        teamName: new FormControl('', [Validators.required])
    });
}
