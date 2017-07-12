"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var ProfilesHubService = (function (_super) {
    __extends(ProfilesHubService, _super);
    function ProfilesHubService(_zone, _signalRConnectionService) {
        var _this = _super.call(this, null) || this;
        _this._zone = _zone;
        _this._signalRConnectionService = _signalRConnectionService;
        var connection = $.hubConnection("/");
        _this._hub = connection.createHubProxy("profilesHub");
        connection.start().done(function () {
        });
        return _this;
    }
    return ProfilesHubService;
}(rxjs_1.BehaviorSubject));
exports.ProfilesHubService = ProfilesHubService;
//# sourceMappingURL=profiles-hub.service.js.map