import { Storage, isNumeric, Log } from "../utilities";
import { Route } from "./route";
import { environment } from "../environment";

export const routerKeys = {
    currentRoute: "[Router] current route"
}

export class Router {
    constructor(
        private _routes: Array<Route> = [],
        private _storage: Storage,
        private _environment: { useUrlRouting: boolean } = environment
    ) { }


    public get activatedRoute(): ActivatedRoute {
        return Object.assign(this._routes.find(r => r.name === this._routeName), { routeParams: this._routeParams });
    }

    public addEventListener(callback: any) {
        this._callbacks.push(callback);
        if (this._routeName)
            callback({ routeName: this._routeName, routeParams: this._routeParams, nextRoute: this.activatedRoute });
    }

    public removeEventListener(callback: any) {
        this._callbacks.splice(this._callbacks.indexOf(callback), 1);
    }

    public setRoutes(routes: Array<Route>) {
        this._routes = routes;
        this._addEventListeners();
        this._onChanged({ route: this._initialRoute });
    }

    public navigate(routeSegments: Array<any>) {
        this._onChanged({ routeSegments: routeSegments });
    }

    public navigateUrl(path: string) {
        this._onChanged({ routeSegments: path.slice(1, path.length).split("/") });
    }

    private _onChanged(state: { route?: string, routeSegments?: Array<any> }) {

        let routeParams = {};
        let match = false;
        if (state.routeSegments)
            state.route = "/" + state.routeSegments.join("/");

        for (var i = 0; i < this._routes.length; i++) {
            if (state.route == this._routes[i].path) {
                this._onRouteMatch(this._routes[i].name);
                match = true;
            }
        }

        if (!match) {
            const _currentSegments = state.route.substring(1).split("/");
            for (let i = 0; i < this._routes.length; i++) {

                const segments = this._routes[i].path.substring(1).split("/");

                if (_currentSegments.length === segments.length) {

                    for (var x = 0; x < segments.length; x++) {
                        if (_currentSegments[x] == segments[x]) {
                            match = true;
                        } else if (segments[x].charAt(0) == ":") {
                            match = true;
                            routeParams[segments[x].substring(1)] = _currentSegments[x];
                        } else {
                            match = false;
                            break;
                        }
                    }

                    if (match) {
                        this._onRouteMatch(this._routes[i].name, routeParams);
                        i = this._routes.length;
                    }
                }
            }
        }

        if (!match)
            for (var i = 0; i < this._routes.length; i++) {
                if (this._routes[i].path === "*") {
                    this._onRouteMatch(this._routes[i].name);
                    match = true;
                }
            }

        if (this._environment.useUrlRouting)
            history.pushState({}, this._routeName, state.route);

        this._storage.put({ name: routerKeys.currentRoute, value: state.route });

        this._callbacks.forEach(callback => callback({ routeName: this._routeName, routeParams: this._routeParams, nextRoute: this.activatedRoute }));

    }

    private _onRouteMatch(name: string, routeParams: any = null) {
        this._routeName = name;
        this._routeParams = routeParams;
    }

    public _addEventListeners() {
        window.onpopstate = () => this._onChanged({ route: window.location.pathname });
    }

    private get _initialRoute(): string { return this._environment.useUrlRouting ? window.location.pathname : this._storage.get({ name: routerKeys.currentRoute }) || "/"; }

    private _routeName: string;
    private _routePath: string;
    private _routeParams;
    private _callbacks: Array<any> = [];
    private static _instance;
}

