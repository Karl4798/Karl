// Required imports
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  templateUrl: '../signup/signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent {

  // Error messages
  enteredPhoneNumberError = 'Phone numbers must be in local format. e.g. 0712505555';
  enteredEmailError = 'Please enter a correctly formatted e-mail address';
  enteredPasswordError = 'Please enter a password that contains lower case, upper case letters and at least one number. (6-20 characters)';
  isLoading = 'false';

  // Constructor with required injections
  constructor(public authService: AuthService) {}

  // onSignup button press event handler
  onSignup(form: NgForm) {

    // If the form is invalid, then return the view and do not create the user account
    if (form.invalid) {
      return;
    }

    // Calls a method in AuthService to create the user account
    this.authService.createUser(form.value.enteredEmail,
                                form.value.enteredPassword,
                                form.value.enteredPhoneNumber);
    console.log(form.value);

  }

}
