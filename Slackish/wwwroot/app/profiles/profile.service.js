"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var rxjs_1 = require("rxjs");
var ProfileService = (function () {
    function ProfileService(_http) {
        this._http = _http;
    }
    ProfileService.prototype.add = function (entity) {
        return this._http
            .post(this._baseUrl + "/api/profile/add", entity)
            .map(function (data) { return data.json(); })
            .catch(function (err) {
            return rxjs_1.Observable.of(false);
        });
    };
    ProfileService.prototype.get = function () {
        return this._http
            .get(this._baseUrl + "/api/profile/get")
            .map(function (data) { return data.json(); })
            .catch(function (err) {
            return rxjs_1.Observable.of(false);
        });
    };
    ProfileService.prototype.getById = function (options) {
        return this._http
            .get(this._baseUrl + "/api/profile/getById?id=" + options.id)
            .map(function (data) { return data.json(); })
            .catch(function (err) {
            return rxjs_1.Observable.of(false);
        });
    };
    ProfileService.prototype.remove = function (options) {
        return this._http
            .delete(this._baseUrl + "/api/profile/remove?id=" + options.id)
            .map(function (data) { return data.json(); })
            .catch(function (err) {
            return rxjs_1.Observable.of(false);
        });
    };
    Object.defineProperty(ProfileService.prototype, "_baseUrl", {
        get: function () { return ""; },
        enumerable: true,
        configurable: true
    });
    return ProfileService;
}());
ProfileService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], ProfileService);
exports.ProfileService = ProfileService;
//# sourceMappingURL=profile.service.js.map