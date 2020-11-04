import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { StateService } from '../state.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  // Variables used to store authentication data
  userIsAuthenticated: any;
  private authListenerSubs: Subscription;
  userName: string;

  // Constructor with required injections
  constructor(private authService: AuthService, private stateService: StateService) {}

  // Method used to initialize the class
  ngOnInit() {

    this.authService.getAuthStatus().then(res => {
      this.userIsAuthenticated = res;

      if (res) {
        this.authService.getUserName().then(resp => {
          this.userName = resp.toString();
          this.stateService.setCurrentUserName(this.userName);
        });
      }

    });

    this.authListenerSubs = this.authService
      .getAuthStatusListener()
      .subscribe(isAuthenticated => {
        this.userIsAuthenticated = isAuthenticated;
      });

    this.stateService.currentUserName$
      .subscribe(
        userName => {
        this.userName = userName;
      });
  }

  // Method used to handle the onLogout button click event
  onLogout() {
    this.authService.logout();
  }

  ngOnDestroy() {
    this.authListenerSubs.unsubscribe();
  }

}
