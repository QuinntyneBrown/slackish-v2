import {Component,OnInit} from "@angular/core";
import {ProfilesService} from "../profiles/profile.service";
import {Profile} from "../profiles/profile.model";
import {ConversationsService} from "./conversations.service";
import {Conversation} from "./conversation.model";
import {Storage,constants} from "../shared";

@Component({
    templateUrl: "./conversation-page.component.html",
    styleUrls: ["./conversation-page.component.css"],
    selector: "ce-conversation-page"
})
export class ConversationPageComponent implements OnInit {
    constructor(
        private _conversationsService: ConversationsService,
        private _profilesService: ProfilesService,
        private _storage: Storage
    ) {

    }

    async ngOnInit() {
        this.otherProfiles = await this._profilesService.getOtherProfiles();
        this.conversations = await this._conversationsService.getByCurrentProfile();        
    }

    public get username() {
        return this._storage.get({ name: constants.CURRENT_PROFILE_KEY }).profile.user.username;
    }

    public otherProfiles: Array<Profile> = [];
    public conversations: Array<Conversation> = [];
}