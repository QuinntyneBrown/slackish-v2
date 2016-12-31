import { createElement } from "./create-element";

export class Template {

    constructor(
        private _createElement: any = createElement
    ) { }
    private static _instance;

    public static get Instance():Template {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get = (options: { templateUrl?: string, html?: string }): Promise<any> => {
        return new Promise((resolve) => {
            resolve(this._createElement(options.html));
        });
    }

}