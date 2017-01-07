import { AppRouterOutletComponent } from "./app-router-outlet.component";
import { Router } from "./router";
import { IocContainer } from "./ioc-container";
import { Store, StorageConfiguration, Storage } from "./utilities";
import { setReducers } from "./set-reducers";

const template = require("./app.component.html");
const styles = require("./app.component.scss");

export class AppComponent extends HTMLElement {
    constructor(
        private _store: Store = IocContainer.resolve(Store),
        private _storage: Storage = IocContainer.resolve(Storage)
    ) { 
        super();
    }
    
    connectedCallback() {                
        setReducers();
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();        
    }

    private async _bind() {
        this._appRouterOutlet = new AppRouterOutletComponent(this._routerOutletElement, IocContainer.resolve(Router));
    }
    
    private _appRouterOutlet: AppRouterOutletComponent;
    private get _routerOutletElement(): HTMLElement { return this.querySelector(".router-outlet") as HTMLElement; }
}

customElements.define(`ce-app`, AppComponent);
