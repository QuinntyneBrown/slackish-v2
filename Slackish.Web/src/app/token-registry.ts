import { ConversationService } from "./conversations";
import { MessageService } from "./messages";
import { ProfileService, LoginRedirect, AuthorizedRouteMiddleware, CurrentProfile } from "./profiles";
import { Router } from "./router";
import { Environment } from "./environment"

import { Storage, StorageConfiguration, Store } from "./utilities";

export class TokenRegistry {
    public static get tokens():Array<any> {
        return [
            //AuthorizedRouteMiddleware,
            Environment,
            Storage,
            StorageConfiguration,
            ConversationService,
            CurrentProfile,
            MessageService,
            ProfileService,
            Router,            
            LoginRedirect,
            Store
        ];
    }    
}