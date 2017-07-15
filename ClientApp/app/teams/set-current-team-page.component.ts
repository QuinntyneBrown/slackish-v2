import {Component} from "@angular/core";
import {TeamsService} from "./teams.service";
import {Router} from "@angular/router";

@Component({
    templateUrl: "./set-current-team-page.component.html",
    styleUrls: ["./set-current-team-page.component.css"],
    selector: "ce-set-current-team-page"
})
export class SetCurrentTeamPageComponent {
    constructor(private _teamsService: TeamsService, private _router: Router) {}

    async ngOnInit() {
        this.teams = await this._teamsService.get();
    }

    public async setCurrentTeam($event: { detail: { teamName:string }}) {
        this._teamsService.setCurrentTeam({ teamName: $event.detail.teamName });
        this._router.navigateByUrl("/");
    }

    public teams: Array<any> = [];
}