import { Component, SecurityContext, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DepartmentsService } from '../department.service';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Department } from '../department.model';

@Component(
  {
    selector: 'app-department-create',
    templateUrl: './department-create.component.html',
    styleUrls: ['./department-create.component.css']
  }
)

export class DepartmentCreateComponent implements OnInit {

  // Variables used to store department information
  private typeCreate = true;
  private departmentId: string;
  department: Department;
  heading: string;

  // Constructor with required injections
  constructor(public departmentService: DepartmentsService, public route: ActivatedRoute, protected sanitizer: DomSanitizer,
              private router: Router) {}

  // Error message
  enteredNameError = 'Invalid department name. Please ensure the department name is longer than 2 characters.';

  // Variable used to store department name
  enteredName = '';

  // Initialization of the class
  ngOnInit(): void {
    this.route.paramMap.subscribe((paramMap: ParamMap) => {
      if (paramMap.has('departmentId')) {
        this.typeCreate = false;
        this.departmentId = paramMap.get('departmentId');
        this.departmentService.getDepartment(this.departmentId).subscribe(departmentData => {
          this.department = {
            id: departmentData._id,
            Name: departmentData.Name,
          };
          this.heading = 'Edit Existing Department';
        });
      } else {
        this.typeCreate = true;
        this.departmentId = null;
        this.heading = 'Create New Department';
      }
    });
  }

  // Handles the onAddDepartment button click event
  onAddDepartment(PostForm: NgForm) {

    // Checks if the form is valid, and if not it will return the view
    if (PostForm.invalid) {
      return;
    }

    // Creates the department or updates existing department
    if (this.typeCreate) {
      this.departmentService.addDepartment(
      this.sanitizer.sanitize(SecurityContext.HTML, PostForm.value.enteredName));
    } else {
      this.departmentService.updateDepartment(
      this.departmentId,
      this.sanitizer.sanitize(SecurityContext.HTML, PostForm.value.enteredName),
    );
      PostForm.resetForm();
    }

    PostForm.resetForm();

  }

}

