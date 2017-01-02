import { Conversation } from "./conversation.model";
import { ConversationService } from "./conversation.service";
import { IocContainer } from "../ioc-container";

const template = require("./conversation-list.component.html");
const styles = require("./conversation-list.component.scss");

export class ConversationListComponent extends HTMLElement {
    constructor(
		private _document: Document = document,
		private _conversationService: ConversationService = IocContainer.resolve(ConversationService)) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
		this._bind();
    }

	private async _bind() {
		const results = await this._conversationService.get() as string;
		const conversations: Array<Conversation> = JSON.parse(results) as Array<Conversation>;
        for (var i = 0; i < conversations.length; i++) {
			let el = this._document.createElement(`ce-conversation-item`);
			el.setAttribute("entity", JSON.stringify(conversations[i]));
			this.appendChild(el);
        }	
	}
}

customElements.define("ce-conversation-list", ConversationListComponent);
