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

import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
    templateUrl: "./discover-team-page.component.html",
    styleUrls: [
        "../shared/styles/forms.css",
        "./discover-team-page.component.css"
    ],
    selector: "ce-discover-team-page"
})
export class DiscoverTeamPageComponent {
    constructor(
        private _storage: Storage,
        private _router: Router) { }

    public async tryToSetCurrentTeam($event: { detail: { teamName: string } }) {
        this._storage.put({ name: constants.CURRENT_TEAM_KEY, value: { team: { name: $event.detail.teamName } } });
        this._router.navigateByUrl("/login");
    }    
}
