var LoginComponent_1;
import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let LoginComponent = LoginComponent_1 = class LoginComponent {
    constructor(authService, router) {
        this.authService = authService;
        this.router = router;
        this.user = null;
        this.enteredEmailError = 'Please enter a valid email address';
        // tslint:disable-next-line: max-line-length
        this.enteredPasswordError = 'Please enter a password that contains lower case, upper case letters and at least one number. (6-20 characters)';
    }
    onLogin(form) {
        if (form.invalid) {
            return;
        }
        LoginComponent_1.email = form.value.enteredEmail;
        LoginComponent_1.password = form.value.enteredPassword;
        LoginComponent_1.phone = form.value.enteredPhoneNumber;
        this.authService.loginCheck(LoginComponent_1.email, LoginComponent_1.password, LoginComponent_1.phone);
    }
};
LoginComponent = LoginComponent_1 = tslib_1.__decorate([
    Component({
        templateUrl: './login.component.html',
        styleUrls: ['./login.component.css']
    })
], LoginComponent);
export { LoginComponent };
//# sourceMappingURL=login.component.js.map