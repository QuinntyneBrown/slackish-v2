import { Store } from "../utilities";
import { Injectable } from "@angular/core";
import { ProfileService } from "./profile.service";

@Injectable()
export class ProfileActionCreator {
    constructor(private _store: Store) {

    }
}