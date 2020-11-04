import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subject, Observable } from 'rxjs';
import { AuthData } from './auth-data.model';
import { StateService } from '../state.service';
import { MatSnackBar } from '@angular/material';

@Injectable({providedIn: 'root'})
export class AuthService {

  // Constructor with required injections
  constructor(private http: HttpClient, private router: Router, public snackBar: MatSnackBar, private stateService: StateService) {}

  // Variables used to store user information
  private token: string;
  private isAuthenticated = false;
  private authStatusListener = new Subject<boolean>();

  // Gets the signed in user account email address
  getUser(email: string): Observable<AuthData> {
    return this.http.get<AuthData>('/api/users/' + email);
  }

  // Creates the user with passed parameters for email, password, and phone number
  createUser(email: string, password: string, phone: string) {
    const authData: AuthData = {id: null, email, password, phone};
    this.http.post('/api/users/signup', authData)
    .subscribe(
      () => {
        this.router.navigate(['login']);
        this.snackBar.open('Registration was successful!', 'Dismiss', {duration: 4000});
      },
      error => {
        this.authStatusListener.next(false);
      });
  }

  // Method used to log users in, by authenticating passed parameters
  login(email: string, password: string, phone: string, phoneValidated: boolean) {
    const authData: AuthData = {id: null, email, password, phone};
    this.http.post<{token: string}>('/api/users/login', authData)
    .subscribe(response => {
      const token = response.token;
      this.token = token;
      if (this.token != null) {
        if (phoneValidated) {
          this.isAuthenticated = true;
          this.authStatusListener.next(true);
          this.router.navigate(['/posts']);
          this.stateService.setCurrentUserName(email);
          this.snackBar.open('Login was successful!', 'Dismiss', {duration: 4000});
        }
      } else {
          this.authStatusListener.next(false);
      }
    });
  }

  // Checks if the user exists and has passed correct login details (used for OTP)
  loginCheck(email: string, password: string, phone: string) {
    const authData: AuthData = {id: null, email, password, phone};
    this.http.post<{token: string }>('/api/users/logincheck', authData)
    .subscribe(response => {
      const token = response.token;
      this.token = token;
      if (token) {
        this.router.navigate(['/2fa']);
      }
      this.token = null;
    });
  }

  // Method used to log the user out of the web application
  logout() {

    this.http.get('/api/logout').subscribe(response => {
      console.log(response);
    });

    this.token = null;
    this.isAuthenticated = false;
    this.authStatusListener.next(false);
    this.clearAuthData();
    this.router.navigate(['/']);
  }

  private clearAuthData() {
    localStorage.removeItem('token');
  }

  // Method used to get the token from the cookie
  getToken() {
    return this.token;
  }

  // Method used to get the auth status of the user
  async getAuthStatus() {

    const t = await this.http.get<{token: string}>('/api/getcookie').toPromise();
    if (t.token != null) {
      return true;
    }
    return false;
  }

  // Returns the auth status for the user
  getAuthStatusListener() {
    return this.authStatusListener.asObservable();
  }

  // Gets the username (email) from the token
  async getUserName() {

    const emailAddress = await this.http.get<{email: string}>('/api/email').toPromise();
    if (emailAddress != null) {
      return emailAddress;
    }
    return '';
  }

}
