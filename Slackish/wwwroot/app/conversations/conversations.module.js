"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var profiles_1 = require("../profiles");
var conversation_component_1 = require("./conversation.component");
var conversations_hub_service_1 = require("./conversations-hub.service");
var declarables = [conversation_component_1.ConversationComponent];
var providers = [conversations_hub_service_1.ConversationsHubService];
var ConversationsModule = (function () {
    function ConversationsModule() {
    }
    return ConversationsModule;
}());
ConversationsModule = __decorate([
    core_1.NgModule({
        imports: [common_1.CommonModule, profiles_1.ProfilesModule],
        exports: [declarables],
        declarations: [declarables],
        providers: providers
    })
], ConversationsModule);
exports.ConversationsModule = ConversationsModule;
//# sourceMappingURL=conversations.module.js.map