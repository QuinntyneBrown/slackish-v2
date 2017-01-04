import { fetch } from "../utilities";
import { Profile } from "./profile.model";
import { Injectable } from "@angular/core";

@Injectable()
export class ProfileService {
    
    public getCurrentProfile() {
        return fetch({ url: "/api/profile/getcurrentprofile", authRequired: true });
    }

    public getOtherProfiles() {
        return fetch({ url: "/api/profile/getotherprofiles", authRequired: true });
    }

    public getProfileById(id) {
        return fetch({ url: `/api/profile/getprofilebyid?id=${id}`, authRequired: true });
    }

    public tryToRegister(options: {registerRequest: any }) {
        return fetch({ url: `/api/profile/add`, method: "POST", data: options.registerRequest, authRequired: true  });
    }    
}
