import { Router } from "./router";

export class LinkComponent extends HTMLElement {
    constructor(private _router: Router = Router.Instance) {
        super();
    }

    static get observedAttributes() {
        return [
            "routesegments",         
            "route-name"   
        ];
    }

    connectedCallback() {
        this.style.cursor = "pointer";
        this._addEventListeners();
    }

    private _addEventListeners() {
        this.addEventListener("click", this.onClick.bind(this));
        this._router.addEventListener(this.onRouteChanged.bind(this));
    }

    onClick(e: Event) {this._router.navigate(this.routeSegments); }

    disconnectedCallback() { this._router.removeEventListener(this.onRouteChanged.bind(this)); }

    attributeChangedCallback(name, oldValue, newValue) {

        switch (name) {
            case "active-path":
                (this as any).classList.remove("active");
                if (this.route == newValue)
                    (this as any).classList.add("active");

                break;
            case "routesegments":
                if (newValue)
                    this.routeSegments = JSON.parse(newValue);
                break;
            case "route-name":
                this._routeName = newValue;
                break;
        }
    }

    public onRouteChanged(e: any) {        
        (this as any).classList.remove("active");        
        if (this._routeName == this._router.activatedRoute.name)
            (this as any).classList.add("active");
    }

    public routeSegments: Array<any>;
    private _routeName: string;
    public get route() {
        if (!this.routeSegments)
            return "";
        return "/" + this.routeSegments.join("/");
    }

}

document.addEventListener("DOMContentLoaded", () => (window as any).customElements.define(`ce-link`, LinkComponent));
