import { fetch } from "../utilities";
import { Message } from "./message.model";

export class MessageService {
    
    private static _instance: MessageService;

    public static get Instance() {
        this._instance = this._instance || new MessageService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/message/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/message/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/message/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/message/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
