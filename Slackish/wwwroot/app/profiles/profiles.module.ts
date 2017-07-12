import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ProfileListComponent } from './profile-list.component';

const declarables = [ProfileListComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class ProfilesModule { }
