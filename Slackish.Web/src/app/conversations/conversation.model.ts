import { Profile } from "../profiles";
import { Message } from "../messages";

export class Conversation { 
	public id:any;
    public name: string;
    public profiles: Array<Profile> = [];
    public messages: Array<Message> = [];
}
 