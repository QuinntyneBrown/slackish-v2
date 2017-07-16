import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import {TeamsService} from './teams.service';

const declarables = [];

const providers = [TeamsService];

@NgModule({
    imports: [CommonModule,FormsModule,ReactiveFormsModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class TeamsModule { }
