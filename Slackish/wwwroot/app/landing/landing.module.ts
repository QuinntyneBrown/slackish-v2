import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { LandingPageComponent } from './landing-page.component';

const declarables = [LandingPageComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class LandingModule { }
