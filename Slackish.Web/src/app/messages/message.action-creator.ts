import { Store } from "../utilities";
import { Injectable } from "@angular/core";
import { messageActions } from "./message.actions";
import { MessageService } from "./message.service";

@Injectable()
export class MessageActionCreator {
    constructor(
        private _messageService: MessageService,
        private _store: Store) {
    }

    public async send(options: { content:any, otherProfileId:any }) {
        const results = await this._messageService.send(options);
        this._store.dispatch({
            type: messageActions.SEND,
            payload: results
        });
    }

    public async getMessagesByOtherProfileId(options: { otherProfileId: any }) {
        const results = await this._messageService.getByOtherProfile(options);
        this._store.dispatch({
            type: messageActions.GET_BY_OTHER_PROFILE,
            payload: results
        });
    }
}