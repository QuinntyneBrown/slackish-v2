"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var landing_1 = require("../landing");
exports.routes = [
    {
        path: '',
        component: landing_1.LandingPageComponent
    }
];
exports.RoutingModule = router_1.RouterModule.forRoot(exports.routes.slice());
exports.routedComponents = [
    landing_1.LandingPageComponent
];
//# sourceMappingURL=routing.module.js.map