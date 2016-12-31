declare interface ActivatedRoute {
    name: string;
    params: any;
    authRequired: boolean;
    path: string;
    segments: Array<any>;
    routeParams: any;
}

declare interface RouteChangeOptions {
    currentView: HTMLElement;
    nextRouteName: string;
    previousRouteName: string;
    routeParams: any;
    cancelled: any;
    nextRoute?: ActivatedRoute;
}

declare var Quill;

declare var rome: any;

/**
 * Custom Elements v1
 *
 * Based on https://www.w3.org/TR/2016/WD-custom-elements-20160830/
 */

interface Window {
    readonly customElements: CustomElementRegistry;
}
declare let customElements: CustomElementRegistry;

interface CustomElementRegistry {
    define(name: string, constructor: Function, options?: ElementDefinitionOptions): void;
    get(name: string): any;
    whenDefined(name: string): Promise<void>;
}

interface ElementDefinitionOptions {
    extends: string;
}