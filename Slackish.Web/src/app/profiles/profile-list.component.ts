import { Profile } from "./profile.model";
import { ProfileService } from "./profile.service";
import { IocContainer } from "../ioc-container";

const template = require("./profile-list.component.html");
const styles = require("./profile-list.component.scss");

export class ProfileListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
        private _profileService: ProfileService = IocContainer.resolve(ProfileService)) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private async _bind() {
		const results = await this._profileService.get() as string;
		const profiles: Array<Profile> = JSON.parse(results) as Array<Profile>;
        for (var i = 0; i < profiles.length; i++) {
			let el = this._document.createElement(`ce-profile-item`);
			el.setAttribute("entity", JSON.stringify(profiles[i]));
			this.appendChild(el);
        }	
	}
}

customElements.define("ce-profile-list", ProfileListComponent);
