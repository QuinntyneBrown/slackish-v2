import { Injectable } from "@angular/core";

@Injectable()
export class Environment {
    public production: boolean = true;
    public applicationContextName:string = "slackishApp";
    public baseUrl: string = "";
    public useUrlRouting:boolean = true;
}