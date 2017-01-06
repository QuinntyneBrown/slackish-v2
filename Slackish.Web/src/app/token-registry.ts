import { ConversationService } from "./conversations";
import { MessageService } from "./messages";
import { ProfileService, LoginRedirect, AuthorizedRouteMiddleware } from "./profiles";
import { Router } from "./router";
import { Environment } from "./environment"

import { Storage, StorageConfiguration } from "./utilities";

export class TokenRegistry {
    public static get tokens():Array<any> {
        return [
            AuthorizedRouteMiddleware,
            ConversationService,
            MessageService,
            ProfileService,
            Router,
            Storage,
            StorageConfiguration,
            Environment,
            LoginRedirect
        ];
    }    
}