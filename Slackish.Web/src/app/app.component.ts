import { AppRouterOutletComponent } from "./app-router-outlet.component";
import { Router } from "./router";
import { IocContainer } from "./ioc-container";
import { Store } from "./utilities";
import { getByCurrentProfileReducer } from "./conversations";
import { } from "./messages";
import { } from "./profiles";

const template = require("./app.component.html");
const styles = require("./app.component.scss");

export class AppComponent extends HTMLElement {
    constructor(
        private _store: Store = IocContainer.resolve(Store)
    ) {
        super();
    }
    
    connectedCallback() {
        this._setReducers();
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();        
    }

    private async _bind() {
        this._appRouterOutlet = new AppRouterOutletComponent(this._routerOutletElement,IocContainer.resolve(Router));
    }

    private _setReducers() {
        this._store.reducers.push(getByCurrentProfileReducer);
    }
    
    private _appRouterOutlet: AppRouterOutletComponent;
    private get _routerOutletElement(): HTMLElement { return this.querySelector(".router-outlet") as HTMLElement; }
}

customElements.define(`ce-app`,AppComponent);
