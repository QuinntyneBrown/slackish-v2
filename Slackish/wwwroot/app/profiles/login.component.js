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
var forms_1 = require("@angular/forms");
var LoginComponent = (function () {
    function LoginComponent(_renderer, _elementRef) {
        this._renderer = _renderer;
        this._elementRef = _elementRef;
        this.tryToLogin = new core_1.EventEmitter();
        this.form = new forms_1.FormGroup({
            username: new forms_1.FormControl('', [forms_1.Validators.required]),
            password: new forms_1.FormControl('', [forms_1.Validators.required])
        });
    }
    Object.defineProperty(LoginComponent.prototype, "username", {
        get: function () {
            return this._elementRef.nativeElement.querySelector("#username");
        },
        enumerable: true,
        configurable: true
    });
    LoginComponent.prototype.ngAfterViewInit = function () {
        this._renderer.invokeElementMethod(this.username, 'focus', []);
    };
    return LoginComponent;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], LoginComponent.prototype, "tryToLogin", void 0);
LoginComponent = __decorate([
    core_1.Component({
        template: require("./login.component.html"),
        styles: [require("./login.component.scss")],
        selector: "ce-login"
    }),
    __metadata("design:paramtypes", [core_1.Renderer, core_1.ElementRef])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map