import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { DepartmentsService } from '../department.service';
import { Department } from '../department.model';


@Component({
  selector: 'app-department-placed',
  templateUrl: './department-placed.component.html',
  styleUrls: ['./department-placed.component.css']
})

export class DepartmentPlacedComponent implements OnInit, OnDestroy {

  departments: Department [] = [];
  userisAuthenticated = false;
  private authStatusSubscription: Subscription;
  private departmentsSubscription: Subscription;

  // Constructor with required injections
  constructor(public departmentService: DepartmentsService, private authService: AuthService) {}

  // Initialization of the class
  ngOnInit() {
    this.departmentService.getDepartments();
    this.departmentsSubscription = this.departmentService.getDepartmentUpdateListener()
    .subscribe((departments: Department[]) => {
      this.departments = departments;
    });

    this.authService.getAuthStatus().then(res => {
      this.userisAuthenticated = res;
    });
    this.authStatusSubscription = this.authService
      .getAuthStatusListener()
      .subscribe(isAuthenticated => {
        this.userisAuthenticated = isAuthenticated;
    });
  }

  // Handles delete action method
  onDelete(departmentID: string) {
    this.departmentService.deleteDepartment(departmentID);
  }

  ngOnDestroy() {
    this.departmentsSubscription.unsubscribe();
  }

}
