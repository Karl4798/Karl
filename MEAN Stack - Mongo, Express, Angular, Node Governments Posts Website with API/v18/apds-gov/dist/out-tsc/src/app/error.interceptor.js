import * as tslib_1 from "tslib";
// Required imports
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ErrorComponent } from './error/error.component';
let ErrorInterceptor = class ErrorInterceptor {
    constructor(dialog) {
        this.dialog = dialog;
    }
    intercept(req, next) {
        return next.handle(req).pipe(catchError((error) => {
            // Default message to display
            let errorMessage = 'An Unknown Error has occured';
            // Provides more details if it's not an unknown error
            if (error.error.message) {
                errorMessage = error.error.message;
            }
            // Show the error in the console, and display a dialog message
            console.log(error);
            this.dialog.open(ErrorComponent, { data: { message: errorMessage } });
            return throwError(error);
        }));
    }
};
ErrorInterceptor = tslib_1.__decorate([
    Injectable()
], ErrorInterceptor);
export { ErrorInterceptor };
//# sourceMappingURL=error.interceptor.js.map