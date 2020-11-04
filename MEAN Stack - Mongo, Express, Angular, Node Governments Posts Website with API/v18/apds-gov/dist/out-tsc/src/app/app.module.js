import * as tslib_1 from "tslib";
import { MatInputModule, MatCardModule, MatButtonModule, MatExpansionModule, MatDialogModule, MatSnackBarModule, MatSelectModule, MatToolbarModule, MatIconModule } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AuthInterceptor } from './auth/auth-interceptor';
import { ErrorInterceptor } from './error.interceptor';
import { ErrorComponent } from './error/error.component';
import { PostPlacedComponent } from './posts/post-placed/post-placed.component';
import { PostCreateComponent } from './posts/post-create/post-create.component';
import { HeaderComponent } from './header/header.component';
import { AngularFireModule } from '@angular/fire';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { WindowService } from './window.service';
import * as firebase from 'firebase';
import { PhoneLoginComponent } from './auth/phone-login/phone-login.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
const config = {
    apiKey: 'AIzaSyCyTF33ad0Q_RgQK5qNOrMD-thoSwztIPM',
    authDomain: 'fawithfirebase-42978.firebaseapp.com',
    databaseURL: 'https://fawithfirebase-42978.firebaseio.com',
    projectId: 'fawithfirebase-42978',
    storageBucket: 'fawithfirebase-42978.appspot.com',
    messagingSenderId: '800417042660'
};
firebase.initializeApp(config);
let AppModule = class AppModule {
};
AppModule = tslib_1.__decorate([
    NgModule({
        declarations: [
            AppComponent,
            PostCreateComponent,
            PostPlacedComponent,
            LoginComponent,
            SignupComponent,
            ErrorComponent,
            HeaderComponent,
            PhoneLoginComponent,
            FooterComponent,
            HomeComponent,
        ],
        imports: [
            BrowserModule,
            AngularFireModule.initializeApp(config),
            AngularFireAuthModule,
            AppRoutingModule,
            FormsModule,
            BrowserAnimationsModule,
            MatInputModule,
            MatCardModule,
            MatButtonModule,
            MatExpansionModule,
            MatToolbarModule,
            HttpClientModule,
            MatSnackBarModule,
            MatSelectModule,
            MatDialogModule,
            MatIconModule
        ],
        providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
            { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
            WindowService],
        bootstrap: [AppComponent],
        entryComponents: [ErrorComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map