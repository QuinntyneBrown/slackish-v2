export class CurrentProfile {
    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }
}