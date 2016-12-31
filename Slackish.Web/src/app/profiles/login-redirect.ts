import { Router } from "../router";

export class LoginRedirect {

    constructor(private _router: Router = Router.Instance) { }

    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new LoginRedirect();
        return this._instance;
    }

    public loginUrl: string = "login";

    public lastPath: string;

    public defaultPath: string = "";

    public setLoginUrl = (value) => {
        this.loginUrl = value;
    }

    public setDefaultUrl = (value) => {
        this.defaultPath = value;
    }

    setLastPath(path: string) {
        this.lastPath = path;        
    }
    
    redirectPreLogin = () => {
        if (this.lastPath) {            
            this._router.navigateUrl(this.lastPath);            
            this.lastPath = "";
        } else {
            this._router.navigateUrl(this.defaultPath);
        }

    }
}