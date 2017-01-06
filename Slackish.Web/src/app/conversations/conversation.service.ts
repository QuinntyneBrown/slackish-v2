import { fetch } from "../utilities";
import { Conversation } from "./conversation.model";
import { Injectable } from "@angular/core";

@Injectable()
export class ConversationService {   
    public get() {
        return fetch({ url: "/api/conversation/get", authRequired: true });
    }

    public getByCurrentProfile() {
        return fetch({ url: "/api/conversation/getbycurrentprofile", authRequired: true });
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
