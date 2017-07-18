import {Component,Input, OnInit,ViewEncapsulation} from "@angular/core";
import {TeamsService} from "./teams.service";
import {Storage} from "../shared/services/storage.service";
import {constants} from "../shared/constants";
import {Router} from "@angular/router";

@Component({
    templateUrl: "./create-team-page.component.html",
    styleUrls: ["./create-team-page.component.css"],
    selector: "ce-create-team-page",
    encapsulation: ViewEncapsulation.Emulated
})
export class CreateTeamPageComponent {
    constructor(
        private _router: Router,
        private _storage: Storage,
        private _teamsService: TeamsService) {

    }

    public async tryToAddTeam($event) {
        await this._teamsService.create({ team: $event.detail.team });

        this._storage.put({
            name: constants.CURRENT_TEAM_KEY, value: await this._teamsService.getByName({ teamName: $event.detail.team.name })
        });

        this._router.navigateByUrl("/profile/create");
    }
}
