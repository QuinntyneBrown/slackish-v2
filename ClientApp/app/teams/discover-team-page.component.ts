import { Component } from "@angular/core";
import { TeamsService } from "./teams.service";
import { Router } from "@angular/router";

@Component({
    templateUrl: "./discover-team-page.component.html",
    styleUrls: ["./discover-team-page.component.css"],
    selector: "ce-discover-team-page"
})
export class DiscoverTeamPageComponent {
    constructor(
        private _teamsService: TeamsService,
        private _router: Router) { }

    async ngOnInit() {
        this.teams = await this._teamsService.get();
    }

    public async setCurrentTeam($event: { detail: { teamName: string } }) {
        this._teamsService.setCurrentTeam({ teamName: $event.detail.teamName });
        this._router.navigateByUrl("/");
    }

    public teams: Array<any> = [];
}
