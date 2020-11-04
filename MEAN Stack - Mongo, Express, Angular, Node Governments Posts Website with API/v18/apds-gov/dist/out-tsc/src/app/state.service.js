import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
let StateService = class StateService {
    constructor() {
        // BehaviorSubject to store UserName
        this.currentUserNameStore = new BehaviorSubject('');
        // Make UserName store Observable
        this.currentUserName$ = this.currentUserNameStore.asObservable();
    }
    // Setter to update UserName
    setCurrentUserName(userName) {
        this.currentUserNameStore.next(userName);
    }
};
StateService = tslib_1.__decorate([
    Injectable({ providedIn: 'root' })
], StateService);
export { StateService };
//# sourceMappingURL=state.service.js.map