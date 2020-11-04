import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../auth.service';
import { AuthData } from '../auth-data.model';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {

  // Variables used to store account information
  public static email: any;
  public static password: any;
  public static phone: any;

  // AuthData object used when logging in the user
  user: AuthData = null;

  // Error messages delared and assigned
  enteredEmailError = 'Please enter a valid email address';
  enteredPasswordError = 'Please enter a password that contains lower case, upper case letters and at least one number.';

  // Constructor with required injections
  constructor(public authService: AuthService) {}

  // onLogin button press event
  onLogin(form: NgForm) {

    // If the form is invalid, then return the view and do not assign values
    if (form.invalid) {
      return;
    }

    // Sets variables from form input
    LoginComponent.email = form.value.enteredEmail;
    LoginComponent.password = form.value.enteredPassword;
    LoginComponent.phone = form.value.enteredPhoneNumber;

    // Checks the database to see if the user is valid
    this.authService.loginCheck(
      LoginComponent.email,
      LoginComponent.password,
      LoginComponent.phone);
  }

}
