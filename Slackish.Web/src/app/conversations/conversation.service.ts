import { fetch } from "../utilities";
import { Conversation } from "./conversation.model";

export class ConversationService {
    
    private static _instance: ConversationService;

    public static get Instance() {
        this._instance = this._instance || new ConversationService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/conversation/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/conversation/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/conversation/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/conversation/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
