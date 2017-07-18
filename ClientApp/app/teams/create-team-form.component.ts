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

import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
    templateUrl: "./create-team-form.component.html",
    styleUrls: [
        "../shared/styles/forms.css",
        "./create-team-form.component.css"
    ],
    selector: "ce-create-team-form"
})
export class CreateTeamFormComponent {
    constructor() {
        this.tryToCreate = new EventEmitter();
    }

    @Output()
    public tryToCreate: EventEmitter<any>;

    public form = new FormGroup({
        teamName: new FormControl('', [Validators.required])
    });
}
