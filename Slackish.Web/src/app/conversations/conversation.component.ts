import { IocContainer } from "../ioc-container";
import { ProfileService, Profile } from "../profiles";
import { MessageService, Message } from "../messages";
import { Router } from "../router";

const template = require("./conversation.component.html");
const styles = require("./conversation.component.scss");

export class ConversationComponent extends HTMLElement {
    constructor(
        private _profileService: ProfileService = IocContainer.resolve(ProfileService),
        private _messageService: MessageService = IocContainer.resolve(MessageService),
        private _router: Router = IocContainer.resolve(Router),
    ) {
        super();
    }

    static get observedAttributes () {
        return [
            "profile-id"
        ];
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

    private _profileId: any;

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "profile-id":
                this._profileId = newValue;
                break;
        }
    }
}

customElements.define(`ce-conversation`,ConversationComponent);
