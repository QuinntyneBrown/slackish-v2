import { TokenRegistry } from "./token-registry";
import { ReflectiveInjector } from "@angular/core";

export class IocContainer {
    constructor() {
        this._injector = ReflectiveInjector.resolveAndCreate(TokenRegistry.tokens);
    }

    private static _instance: IocContainer;

    private static get Instance(): IocContainer {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public static resolve(token: any) {
        return this.Instance._injector.get(token);
    }

    private _injector: ReflectiveInjector;
}