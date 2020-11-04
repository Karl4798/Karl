import * as tslib_1 from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SignupComponent } from './auth/signup/signup.component';
import { LoginComponent } from './auth/login/login.component';
import { PostPlacedComponent } from './posts/post-placed/post-placed.component';
import { PostCreateComponent } from './posts/post-create/post-create.component';
import { AuthGuardService } from './auth/auth.guard';
import { PhoneLoginComponent } from './auth/phone-login/phone-login.component';
import { HomeComponent } from './home/home.component';
const routes = [
    { path: '', component: HomeComponent },
    { path: 'posts', component: PostPlacedComponent },
    { path: 'create', component: PostCreateComponent },
    { path: 'edit/:postId', component: PostCreateComponent },
    { path: 'login', component: LoginComponent },
    { path: '2fa', component: PhoneLoginComponent },
    { path: 'signup', component: SignupComponent },
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = tslib_1.__decorate([
    NgModule({
        imports: [RouterModule.forRoot(routes)],
        exports: [RouterModule],
        providers: [AuthGuardService]
    })
], AppRoutingModule);
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map