import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignupComponent } from './auth/signup/signup.component';
import { LoginComponent } from './auth/login/login.component';
import { PostPlacedComponent } from './posts/post-placed/post-placed.component';
import { PostCreateComponent } from './posts/post-create/post-create.component';
import { PhoneLoginComponent } from './auth/phone-login/phone-login.component';
import { HomeComponent } from './home/home.component';
import { DepartmentCreateComponent } from './departments/department-create/department-create.component';
import { DepartmentPlacedComponent } from './departments/department-placed/department-placed.component';

// Routes used to navigate the user throughout the website using URLs
const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'posts', component: PostPlacedComponent},
  {path: 'create', component: PostCreateComponent},
  {path: 'edit/:postId', component: PostCreateComponent},
  {path: 'departments', component: DepartmentPlacedComponent},
  {path: 'createdepartment', component: DepartmentCreateComponent},
  {path: 'editdepartment/:departmentId', component: DepartmentCreateComponent},
  {path: 'login', component: LoginComponent},
  {path: '2fa', component: PhoneLoginComponent},
  {path: 'signup', component: SignupComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {}
