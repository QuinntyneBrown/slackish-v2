import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../shared";
import {ProfileListComponent} from './profile-list.component';
import {LoginComponent} from "./login.component";

const declarables = [ProfileListComponent, LoginComponent];
const providers = [];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, SharedModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class ProfilesModule { }
