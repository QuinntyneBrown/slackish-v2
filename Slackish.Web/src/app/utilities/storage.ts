import { STORAGE_KEY } from "./constants";
import { StorageConfiguration } from "./storage-configuration";
import { Injectable } from "@angular/core";

@Injectable()
export class Storage {
    constructor(_configuration: StorageConfiguration) {

        this.onPageHide = this.onPageHide.bind(this);

        this._window = _configuration.window;
        this._localStorage = _configuration.localStorage;
        this._key = _configuration.key;

        this._window.addEventListener("pagehide", this.onPageHide);
    }

    private _localStorage;
    private _window: Window;
    private _key: string;

    private onPageHide() {
        this._localStorage.setItem(this._key, JSON.stringify(this._items));
    }

    private _items = null;

    public get items() {
        if (this._items === null) {
            var storageItems = this._localStorage.getItem(this._key);
            if (storageItems === "null") {
                storageItems = null;
            }
            this._items = JSON.parse(storageItems || "[]");
        }
        return this._items;
    }

    public set items(value: Array<any>) {
        this._items = value;
    }

    public get = (options: { name: string }) => {
        var storageItem = null;
        for (var i = 0; i < this.items.length; i++) {
            if (options.name === this.items[i].name)
                storageItem = this.items[i].value;
        }
        return storageItem;
    }

    public put = (options: { name: string, value: string }) => {
        var itemExists = false;

        this.items.forEach((item: any) => {
            if (options.name === item.name) {
                itemExists = true;
                item.value = options.value
            }
        });

        if (!itemExists) {
            var items = this.items;
            items.push({ name: options.name, value: options.value });
            this.items = items;
            items = null;
        }
    }

    public clear = () => {
        this._items = [];
    }
}