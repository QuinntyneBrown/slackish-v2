import { Storage } from "./storage";
import { Environment } from "../environment";
import { IocContainer } from "../ioc-container";
import { Injectable } from "@angular/core";

export const STORE_KEY = "[Store] store key";

export interface Action {
    type: string;
    payload?: any;
}

@Injectable()
export class Store {
    constructor(private _storage: Storage) {
        this._state = _storage.get({ name: STORE_KEY }) || {};
        
    }

    public dispatch(action: Action) {
        for (var i = 0; i < this.reducers.length; i++) {
            this._state = this.reducers[i](this._state, action);
        }
        this.middlewares.forEach(m => m(action));
        this._storage.put({ name: STORE_KEY, value: this._state });
        this.next(this._state);
    }

    public next(state) { this._observers.forEach(o => o(this._state)); }

    public subscribe(observer) {
        this._observers.push(observer);
        return function () { this.unsubscribe(observer) }.bind(this);
    }

    public unsubscribe(observer) {
        this._observers.splice(this._observers.indexOf(observer), 1);
    }

    private _observers = [];
    public middlewares = [];
    private _state;
    public reducers = [];    
}