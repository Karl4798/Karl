import { Component, OnInit, OnDestroy, HostListener } from '@angular/core';
import { WindowService } from '../../window.service';
import * as firebase from 'firebase';
import { LoginComponent } from '../login/login.component';
import { AuthService } from '../auth.service';
import { AuthData } from '../auth-data.model';
import { throwError } from 'rxjs';
import { ErrorComponent } from 'src/app/error/error.component';
import { MatDialog } from '@angular/material';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'phone-login',
  templateUrl: './phone-login.component.html',
  styleUrls: ['./phone-login.component.css']
})

export class PhoneLoginComponent implements OnInit, OnDestroy {

  // Variables used for reCapture and Firebase OTP login
  windowRef: any;
  phoneNumber: string;
  verificationCode: string = null;
  user: AuthData;

  // Constructor with required injections
  constructor(public authService: AuthService, private win: WindowService, private dialog: MatDialog) { }

  // Initialize method
  ngOnInit() {

    // Used to initialize and render the reCaptcha window
    this.windowRef = this.win.windowRef;
    this.windowRef.recaptchaVerifier = new firebase.auth.RecaptchaVerifier('recaptcha-container');
    this.windowRef.recaptchaVerifier.render();

  }

  // sendLoginCode button action method
  sendLoginCode() {

    // Uses the AuthService to get the user information
    this.authService.getUser(LoginComponent.email).subscribe((data: AuthData) => {

      // Fetches the auth data object and stores it in a local variable
      this.user = data;
      // tslint:disable-next-line: prefer-const
      let stringData = data[0].phone;
      // tslint:disable-next-line: prefer-const
      let formattedPhoneNumber = stringData.replace('0', '+27');
      this.phoneNumber = formattedPhoneNumber;

      // Fetches the phone number
      const num = this.phoneNumber;

      // Gets the verification of the reCaptcha
      const appVerifier = this.windowRef.recaptchaVerifier;

      // Authenticate the user with the OTP
      firebase.auth().signInWithPhoneNumber(num, appVerifier)
            .then(result => {

                this.windowRef.confirmationResult = result;
                this.authService.getUser(LoginComponent.email);
                // tslint:disable-next-line: no-unused-expression
                this.windowRef.window.unloaded;
                jQuery('#recaptcha').replaceWith(jQuery('#submitVerCode'));
            })
            .catch( error =>
            {
              const errorMessage = error;
              console.log(error);
              this.dialog.open(ErrorComponent, {data: {message: errorMessage}});
              return throwError(error);
            });
    });

  }

  // Verifies the login code
  verifyLoginCode() {
    this.windowRef.confirmationResult
                  .confirm(this.verificationCode)
                  .then( result => {

                    this.authService.login(
                      LoginComponent.email,
                      LoginComponent.password,
                      LoginComponent.phone,
                      true);
                    this.windowRef.confirmationResult = false;

    })
    .catch( error => {
      const errorMessage = 'The verification code has expired or is invalid. Please re-send the verification code.';
      console.log(error);
      this.dialog.open(ErrorComponent, {data: {message: errorMessage}});
      return throwError(error);
    });
  }

  @HostListener('unloaded')
  ngOnDestroy() {
    this.windowRef.confirmationResult = null;
   }

}
