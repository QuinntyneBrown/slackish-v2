import { fetch } from "../utilities";
import { Profile } from "./profile.model";

export class ProfileService {
    
    private static _instance: ProfileService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/profile/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/profile/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/profile/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/profile/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
