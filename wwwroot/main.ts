import {enableProdMode} from "@angular/core";
import {AppModule,environment} from "./app";
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

if (environment.production) {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
    .catch(err => console.error(err));