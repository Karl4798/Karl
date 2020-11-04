import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PostsService } from '../post.service';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Post } from '../post.model';
import { DepartmentsService } from 'src/app/departments/department.service';
import { Subscription } from 'rxjs';
import { Department } from 'src/app/departments/department.model';

export interface DepartmentTemp {
  value: string;
  viewValue: string;
}

@Component(
  {
    selector: 'app-post-create',
    templateUrl: './post-create.component.html',
    styleUrls: ['./post-create.component.css']
  }
)

export class PostCreateComponent implements OnInit, OnDestroy {

  // Variables used to store post information
  private typeCreate = true;
  private postId: string;
  post: Post;
  heading: string;
  private departmentsSubscription: Subscription;
  departments: Department [] = [];
  departmentsTemp: DepartmentTemp[] = [];

  // Constructor with required injections
  constructor(public postService: PostsService, public departmentService: DepartmentsService,
              public route: ActivatedRoute) {}

  // Variables used to store error messages
  enteredNameError = 'Invalid post name. Please ensure the post name is longer than 2 characters.';
  enteredDepartmentError = 'Department is invalid. Please enter select a valid department.';
  enteredPostError = 'Post description is invalid. Please enter a description between 1 and 50 characters long.';

  // Variables used to store post information
  enteredName = '';
  enteredDepartment = '';
  enteredPost = '';

  // Method used to initialize the posts class
  ngOnInit(): void {
    this.route.paramMap.subscribe((paramMap: ParamMap) => {
      if (paramMap.has('postId')) {
        this.typeCreate = false;
        this.postId = paramMap.get('postId');
        this.postService.getPost(this.postId).subscribe(postData => {
          this.post = {
            id: postData._id,
            Name: postData.Name,
            Department: postData.Department,
            PlacedPost: postData.PlacedPost
          };
          this.heading = 'Edit Existing Post';
        });
      } else {
        this.typeCreate = true;
        this.postId = null;
        this.heading = 'Create New Post';
      }

      this.departmentService.getDepartments();
      this.departmentsSubscription = this.departmentService.getDepartmentUpdateListener()
        .subscribe((departments: Department[]) => {
      this.departments = departments;

      departments.forEach((element, index) => {
        this.departmentsTemp.push({value: element.Name, viewValue: element.Name});
      });

      });

    });
  }

  // Method used to handle the onAddPost button click event
  onAddPost(PostForm: NgForm) {

    // If the form is invalid, then return the view and do not create the post
    if (PostForm.invalid) {
      return;
    }

    // Create or update the existing post
    if (this.typeCreate) {
      this.postService.addPosts(
        PostForm.value.enteredName,
        PostForm.value.enteredDepartment,
        PostForm.value.enteredPost);
    } else {
      this.postService.updatePost(
        this.postId,
        PostForm.value.enteredName,
        PostForm.value.enteredDepartment,
        PostForm.value.enteredPost
      );
      PostForm.resetForm();
    }

    PostForm.resetForm();

  }

  ngOnDestroy(): void {
    this.departmentsSubscription.unsubscribe();
  }

}

