import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import {TeamsService} from './teams.service';
import {DiscoverTeamFormComponent} from "./discover-team-form.component";
import {CreateTeamFormComponent} from "./create-team-form.component";

import {Routes,RouterModule} from "@angular/router";


const declarables = [
    CreateTeamFormComponent,
    DiscoverTeamFormComponent    
];

const providers = [TeamsService];

@NgModule({
    imports: [CommonModule,FormsModule,ReactiveFormsModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class TeamsModule { }
