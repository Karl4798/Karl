import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import * as firebase from 'firebase';
import { LoginComponent } from '../login/login.component';
import { throwError } from 'rxjs';
import { ErrorComponent } from 'src/app/error/error.component';
let PhoneLoginComponent = class PhoneLoginComponent {
    constructor(authService, win, dialog) {
        this.authService = authService;
        this.win = win;
        this.dialog = dialog;
    }
    ngOnInit() {
        this.windowRef = this.win.windowRef;
        this.windowRef.recaptchaVerifier = new firebase.auth.RecaptchaVerifier('recaptcha-container');
        this.windowRef.recaptchaVerifier.render();
    }
    sendLoginCode() {
        this.authService.getUser(LoginComponent.email).subscribe((data) => {
            this.user = data;
            this.phoneNumber = data[0].phone;
            const num = this.phoneNumber;
            const appVerifier = this.windowRef.recaptchaVerifier;
            firebase.auth().signInWithPhoneNumber(num, appVerifier)
                .then(result => {
                this.windowRef.confirmationResult = result;
                this.authService.getUser(LoginComponent.email);
            })
                .catch(error => {
                let errorMessage = error;
                console.log(error);
                this.dialog.open(ErrorComponent, { data: { message: errorMessage } });
                return throwError(error);
            });
        });
    }
    verifyLoginCode() {
        this.windowRef.confirmationResult
            .confirm(this.verificationCode)
            .then(result => {
            this.authService.login(LoginComponent.email, LoginComponent.password, LoginComponent.phone, true);
            this.windowRef.confirmationResult = false;
        })
            .catch(error => {
            let errorMessage = "The verification code has expired or is invalid. Please re-send the verification code.";
            console.log(error);
            this.dialog.open(ErrorComponent, { data: { message: errorMessage } });
            return throwError(error);
        });
    }
    ngOnDestroy() { }
};
PhoneLoginComponent = tslib_1.__decorate([
    Component({
        // tslint:disable-next-line: component-selector
        selector: 'phone-login',
        templateUrl: './phone-login.component.html',
        styleUrls: ['./phone-login.component.css']
    })
], PhoneLoginComponent);
export { PhoneLoginComponent };
//# sourceMappingURL=phone-login.component.js.map