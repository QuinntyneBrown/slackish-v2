import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";

import {TeamsService} from './teams.service';

const declarables = [];

const providers = [TeamsService];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class TeamsModule { }
