import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
let AuthService = class AuthService {
    constructor(http, router, stateService) {
        this.http = http;
        this.router = router;
        this.stateService = stateService;
        this.isAuthenticated = false;
        this.authStatusListener = new Subject();
    }
    getUser(email) {
        return this.http.get('https://localhost:3000/api/users/' + email);
    }
    createUser(email, password, phone) {
        const authData = { id: null, email, password, phone };
        this.http.post('https://localhost:3000/api/users/signup', authData)
            .subscribe(() => {
            this.router.navigate(['login']);
        }, error => {
            this.authStatusListener.next(false);
        });
    }
    login(email, password, phone, phoneValidated) {
        const authData = { id: null, email, password, phone };
        this.http.post('https://localhost:3000/api/users/login', authData)
            .subscribe(response => {
            const token = response.token;
            this.token = token;
            if (this.token != null) {
                if (phoneValidated) {
                    this.isAuthenticated = true;
                    this.authStatusListener.next(true);
                    this.router.navigate(['/posts']);
                    this.stateService.setCurrentUserName(email);
                }
            }
            else {
                this.authStatusListener.next(false);
            }
        });
    }
    loginCheck(email, password, phone) {
        const authData = { id: null, email, password, phone };
        this.http.post('https://localhost:3000/api/users/login', authData)
            .subscribe(response => {
            const token = response.token;
            this.token = token;
            if (token) {
                this.router.navigate(['/2fa']);
            }
            this.token = null;
        });
    }
    logout() {
        this.token = null;
        this.isAuthenticated = false;
        this.authStatusListener.next(false);
        this.clearAuthData();
        this.router.navigate(['/']);
    }
    clearAuthData() {
        localStorage.removeItem('token');
    }
    getToken() {
        return this.token;
    }
    getIsAuth() {
        return this.isAuthenticated;
    }
    getAuthStatusListener() {
        return this.authStatusListener.asObservable();
    }
};
AuthService = tslib_1.__decorate([
    Injectable({ providedIn: 'root' })
], AuthService);
export { AuthService };
//# sourceMappingURL=auth.service.js.map