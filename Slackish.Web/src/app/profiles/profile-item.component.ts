import { Profile } from "./profile.model";
import { ProfileService } from "./profile.service";
import { Router } from "../router";
import { IocContainer } from "../ioc-container";

const template = require("./profile-item.component.html");
const styles = require("./profile-item.component.scss");

export class ProfileItemComponent extends HTMLElement {
    constructor(
        private _profileService: ProfileService = IocContainer.resolve(ProfileService),
        private _router: Router = IocContainer.resolve(Router)) {
        super();

		this._onDeleteClick = this._onDeleteClick.bind(this);
        this._onEditClick = this._onEditClick.bind(this);
        this._onViewClick = this._onViewClick.bind(this);
    }

    static get observedAttributes() {
        return ["entity"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    disconnectedCallback() {
        this._deleteLinkElement.removeEventListener("click", this._onDeleteClick);
        this._editLinkElement.removeEventListener("click", this._onEditClick);
        this._viewLinkElement.removeEventListener("click", this._onViewClick);
    }

    private _bind() {
        this._nameElement.textContent = this.entity.name;
    }

    private _setEventListeners() {
        this._deleteLinkElement.addEventListener("click", this._onDeleteClick);
        this._editLinkElement.addEventListener("click", this._onEditClick);
        this._viewLinkElement.addEventListener("click", this._onViewClick);
    }

    private async _onDeleteClick(e:Event) {
        await this._profileService.remove({ id: this.entity.id });		
		this.parentNode.removeChild(this);
    }

    private _onEditClick() {
        this._router.navigate(["profile", "edit", this.entity.id]);
    }

    private _onViewClick() {
        this._router.navigate(["profile","view",this.entity.id]);
    }
    
    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "entity":
                this.entity = JSON.parse(newValue);
				break;
        }        
    }

    private get _nameElement() { return this.querySelector("p") as HTMLElement; }
    private get _deleteLinkElement() { return this.querySelector(".entity-item-delete") as HTMLElement; }
    private get _editLinkElement() { return this.querySelector(".entity-item-edit") as HTMLElement; }
    private get _viewLinkElement() { return this.querySelector(".entity-item-view") as HTMLElement; }
    public entity: Profile;
}

customElements.define(`ce-profile-item`,ProfileItemComponent);
