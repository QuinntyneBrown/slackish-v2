import { Storage } from "./storage";

export const STORE_KEY = "[Store] store key";

export interface Action {
    type: string;
    payload?: any;
}

export class Store {
    constructor(private _storage:Storage = Storage.Instance) { }

    private static _instance: Store;
    public static get Instance(): Store {
        this._instance = this._instance || new this();
        return this._instance;
    }
    
    public dispatch(action: Action){    
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
    private _state = Store._initialState;
    public reducers = [];
    private static readonly _initialState = Storage.Instance.get({ name: STORE_KEY }) || {};
}