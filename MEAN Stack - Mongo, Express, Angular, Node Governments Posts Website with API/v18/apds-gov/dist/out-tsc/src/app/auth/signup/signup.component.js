import * as tslib_1 from "tslib";
// Required imports
import { Component } from '@angular/core';
let SignupComponent = class SignupComponent {
    constructor(authService) {
        this.authService = authService;
        // Error messages
        this.enteredPhoneNumberError = 'Phone numbers must be in international format. e.g. +27712505555';
        this.enteredEmailError = 'Please enter a correctly formatted e-mail address';
        this.enteredPasswordError = 'Please enter a password that contains lower case, upper case letters and at least one number. (6-20 characters)';
        this.isLoading = 'false';
    }
    onSignup(form) {
        if (form.invalid) {
            return;
        }
        // Calls a method in AuthService to create the user account
        this.authService.createUser(form.value.enteredEmail, form.value.enteredPassword, form.value.enteredPhoneNumber);
    }
};
SignupComponent = tslib_1.__decorate([
    Component({
        templateUrl: '../signup/signup.component.html',
        styleUrls: ['./signup.component.css']
    })
], SignupComponent);
export { SignupComponent };
//# sourceMappingURL=signup.component.js.map