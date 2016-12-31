import { ConversationService } from "./conversations";
import { MessageService } from "./messages";
import { ProfileService } from "./profiles";
import { Router } from "./router";
import { Storage, StorageConfiguration } from "./utilities";

export class TokenRegistry {
    public static get tokens():Array<any> {
        return [
            ConversationService,
            MessageService,
            ProfileService
        ];
    }
}