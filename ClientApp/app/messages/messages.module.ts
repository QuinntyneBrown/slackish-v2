import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { MessageFormComponent } from "./message-form.component";

const declarables = [MessageFormComponent];
const providers = [];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class MessagesModule { }
