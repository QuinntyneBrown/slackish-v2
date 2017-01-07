import { STORAGE_KEY } from "./constants";
import { Injectable } from "@angular/core";

@Injectable()
export class StorageConfiguration {
    constructor() {

    }
    public key: string = STORAGE_KEY;
    public localStorage = localStorage;
    public window: Window = window;
}