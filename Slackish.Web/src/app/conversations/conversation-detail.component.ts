import { Conversation } from "./conversation.model";

const template = require("./conversation-detail.component.html");
const styles = require("./conversation-detail.component.scss");

export class ConversationDetailComponent extends HTMLElement {
    constructor() {
        super();
    }

    static get observedAttributes () {
        return [
            "conversation"
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

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "conversation":
                this.conversation = JSON.parse(newValue);
                break;
        }
    }

    public conversation: Conversation;
}

customElements.define(`ce-conversation-detail`,ConversationDetailComponent);
