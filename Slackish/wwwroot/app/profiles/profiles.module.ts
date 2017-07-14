import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../shared";
import {ProfileListComponent} from './profile-list.component';
import {LoginComponent} from "./login.component";
import {ProfilesService} from "./profile.service";

const declarables = [ProfileListComponent, LoginComponent];
const providers = [ProfilesService];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, SharedModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class ProfilesModule { }
