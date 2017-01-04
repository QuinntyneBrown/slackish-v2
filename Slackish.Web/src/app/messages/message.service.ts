import { fetch } from "../utilities";
import { Message } from "./message.model";
import { Injectable } from "@angular/core";

@Injectable()
export class MessageService {        
    public getByOtherProfile(options: { otherProfileId }) {
        return fetch({ url: `/api/message/getbyid?id=${options.otherProfileId}`, authRequired: true });
    }

    public send(options: { content: string, otherProfileId:any }) {
        return fetch({ url: `/api/message/add`, method: "POST", data: options, authRequired: true  });
    }    
}
