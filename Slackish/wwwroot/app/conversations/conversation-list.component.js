"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var ConversationListComponent = (function () {
    function ConversationListComponent() {
    }
    return ConversationListComponent;
}());
ConversationListComponent = __decorate([
    core_1.Component({
        templateUrl: "./conversation-list.component.html",
        styleUrls: ["./conversation-list.component.css"],
        selector: "ce-conversation-list"
    })
], ConversationListComponent);
exports.ConversationListComponent = ConversationListComponent;
//# sourceMappingURL=conversation-list.component.js.map