import * as tslib_1 from "tslib";
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
let ErrorComponent = class ErrorComponent {
    constructor(data) {
        this.data = data;
    }
};
ErrorComponent = tslib_1.__decorate([
    Component({
        templateUrl: './error.component.html'
    }),
    tslib_1.__param(0, Inject(MAT_DIALOG_DATA))
], ErrorComponent);
export { ErrorComponent };
//# sourceMappingURL=error.component.js.map