import { RouterOutlet } from "./router";
import { AuthorizedRouteMiddleware } from "./profiles";

export class AppRouterOutletComponent extends RouterOutlet {
    constructor(el: HTMLElement) {
        super(el);
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
                        
        ] as any);

        this.use(new AuthorizedRouteMiddleware());

        super.connectedCallback();
    }

}

customElements.define(`ce-app-router-oulet`,AppRouterOutletComponent);
