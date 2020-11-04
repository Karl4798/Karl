import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
let AuthGuardService = class AuthGuardService {
    constructor(auth, router) {
        this.auth = auth;
        this.router = router;
    }
    canActivate(route, state) {
        const isAuthenticated = this.auth.getIsAuth();
        if (!isAuthenticated) {
            this.router.navigate(['/login']);
        }
        return isAuthenticated;
    }
};
AuthGuardService = tslib_1.__decorate([
    Injectable()
], AuthGuardService);
export { AuthGuardService };
//# sourceMappingURL=auth.guard.js.map