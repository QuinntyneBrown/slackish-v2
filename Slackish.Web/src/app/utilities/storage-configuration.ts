import { STORAGE_KEY } from "./constants";

export class StorageConfiguration {
    public key: string = STORAGE_KEY;
    public localStorage = localStorage;
    public window: Window = window;
}