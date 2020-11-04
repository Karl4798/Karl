// Required imports
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { MatDialog, MatSnackBar } from '@angular/material';
import {ErrorComponent} from './error/error.component';
import { HttpRequest, HttpErrorResponse, HttpInterceptor, HttpHandler } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private dialog: MatDialog, public snackBar: MatSnackBar, private router: Router) {}
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return next.handle(req).pipe(
    catchError((error: HttpErrorResponse) => {

      // Default message to display
      let errorMessage = 'An Unknown Error has occured';

      // Provides more details if it's not an unknown error
      if (error.error.message) {
          errorMessage = error.error.message;
      }

      // If the user does not have permissions to access the resource, then navigate them to the login page and show a snackbar message
      if (error.error.message === 'Not Authorised to Access this Resource.') {
        this.router.navigate(['login']);
        this.snackBar.open(errorMessage, 'Dismiss', {duration: 4000});
        errorMessage = null;
      }

      if (errorMessage != null) {
        // Show the error in the console, and display a dialog message
        console.log(error);
        this.dialog.open(ErrorComponent, {data: {message: errorMessage}});
        return throwError(error);
      }
    })
    );
  }
}

