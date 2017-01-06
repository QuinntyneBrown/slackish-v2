import { IocContainer } from "./ioc-container";
import { RouterOutlet, Router, Route } from "./router";
import { AuthorizedRouteMiddleware } from "./profiles";

export class AppRouterOutletComponent extends RouterOutlet {
    constructor(el: HTMLElement, router:Router) {
        super(el, router);
    }

    connectedCallback() { 
        this.setRoutes([
            { path: "/", name: "conversation", authRequired: true },
            { path: "/register", name: "register", authRequired: false },
            { path: "/login", name: "login", authRequired: false },
            { path: "/converation/:profileId", name: "conversation", authRequired: false },
            { path: "/converation", name: "conversation", authRequired: false },
            { path: "/error", name: "error" },
            { path: "*", name: "not-found" }                        
        ] as Array<Route>);

        this.use(IocContainer.resolve(AuthorizedRouteMiddleware));

        super.connectedCallback();
    }

}

customElements.define(`ce-app-router-oulet`, AppRouterOutletComponent);
