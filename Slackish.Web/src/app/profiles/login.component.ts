import { ProfileService } from "./profile.service";
import { Router } from "../router";
import { LoginRedirect } from "./login-redirect";
import { Storage, TOKEN_KEY } from "../utilities";
import { IocContainer } from "../ioc-container";

const template = require("./login.component.html");
const styles = require("./login.component.scss");

export class LoginComponent extends HTMLElement {
    constructor(
        private _document: Document = document,
        private _router: Router = IocContainer.resolve(Router),
        private _loginRedirect: LoginRedirect = IocContainer.resolve(LoginRedirect),
        private _storage: Storage = IocContainer.resolve(Storage),
        private _profileService: ProfileService = IocContainer.resolve(ProfileService)
    ) {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {

    }

    private _setEventListeners() {

    }

    disconnectedCallback() {

    }

    private get _usernameElement() { return this.querySelector(".username") as HTMLInputElement; }
    private get _passwordElement() { return this.querySelector(".password")[1] as HTMLInputElement; }
    private get _errorElement(): HTMLElement { return this.querySelector(".error") as HTMLElement; }
    private get _loginButtonElement() { return this.querySelector(".submit") as HTMLButtonElement; }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

customElements.define(`ce-login`,LoginComponent);
