import {Component,OnInit, ElementRef} from "@angular/core";
import {ProfilesService} from "../profiles/profile.service";
import {Profile} from "../profiles/profile.model";
import {ConversationsService} from "./conversations.service";
import {Conversation} from "./conversation.model";
import {Storage,constants,popoverEvents} from "../shared";
import {Router} from "@angular/router";

@Component({
    templateUrl: "./conversation-page.component.html",
    styleUrls: ["./conversation-page.component.css"],
    selector: "ce-conversation-page"
})
export class ConversationPageComponent implements OnInit {
    constructor(
        private _conversationsService: ConversationsService,
        private _elementRef: ElementRef,
        private _profilesService: ProfilesService,
        private _router: Router,
        private _storage: Storage
    ) {
        this.navigateToLoginPage = this.navigateToLoginPage.bind(this);
    }

    async ngOnInit() {
        (this._elementRef.nativeElement as HTMLElement).addEventListener(popoverEvents.USERNAME_CLICK, this.navigateToLoginPage);
        this.otherProfiles = await this._profilesService.getOtherProfiles();
        this.conversations = await this._conversationsService.getByCurrentProfile();        
    }

    public navigateToLoginPage() {
        this._router.navigateByUrl("/login");
    }

    public get username() {
        return this._storage.get({ name: constants.CURRENT_PROFILE_KEY }).profile.user.username;
    }

    public get teamName() {
        return this._storage.get({ name: constants.CURRENT_TEAM_KEY }).team.name;
    }

    public otherProfiles: Array<Profile> = [];
    public conversations: Array<Conversation> = [];    
}