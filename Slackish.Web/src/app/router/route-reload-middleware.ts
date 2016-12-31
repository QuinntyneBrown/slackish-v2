import { RouterMiddleware } from "./router-middleware";
import { camelCaseToSnakeCase } from "../utilities";

export class RouteReloadMiddleware extends RouterMiddleware {
    public beforeViewTransition(options: RouteChangeOptions) {        
        if (options.previousRouteName == options.nextRouteName) {            
            for (var prop in options.routeParams) {
                options.currentView.setAttribute(camelCaseToSnakeCase(prop), options.routeParams[prop]);
            }
            options.cancelled = true;
        }
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        return null;
    }

    public afterViewTransition(options: RouteChangeOptions) {

    }
}