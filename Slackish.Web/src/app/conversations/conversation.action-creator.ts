import { conversationActions } from "./conversation.actions";
import { Store } from "../utilities";
import { Injectable } from "@angular/core";
import { ConversationService } from "./conversation.service";

@Injectable()
export class ConversationActionCreator {
    constructor(
        private _store: Store,
        private _conversationService: ConversationService) { }

    public async current() {
        const payload = await this._conversationService.getByCurrentProfile();
        this._store.dispatch({ type: conversationActions.CURRENT, payload });
    }
}