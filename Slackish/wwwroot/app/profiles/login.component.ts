import {
    Component,
    ChangeDetectionStrategy,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    AfterContentInit,
    Renderer,
    ElementRef,
    ViewEncapsulation
} from "@angular/core";

import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
    templateUrl: "./login.component.html",
    styleUrls: [
        "../shared/styles/forms.css",
        "./login.component.css"
    ],
    selector: "ce-login"
})
export class LoginComponent implements AfterViewInit { 

    constructor(private _renderer: Renderer, private _elementRef: ElementRef) { }

    public get username(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#username");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.username, 'focus', []);
    }

    @Output() public tryToLogin: EventEmitter<any> = new EventEmitter();

    public form = new FormGroup({
        username: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required])
    });
}
