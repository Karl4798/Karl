import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let PostCreateComponent = class PostCreateComponent {
    constructor(postService, route, sanitizer, router) {
        this.postService = postService;
        this.route = route;
        this.sanitizer = sanitizer;
        this.router = router;
        this.typeCreate = true;
        this.enteredNameError = 'Invalid post name. Please ensure the post name is longer than 2 characters.';
        this.enteredDepartmentError = 'Department is invalid. Please enter a value between 1 and 10 characters.';
        this.enteredPostError = 'Post description is invalid. Please enter a description between 1 and 50 characters long.';
        this.enteredName = '';
        this.enteredDepartment = '';
        this.enteredPost = '';
    }
    ngOnInit() {
        this.route.paramMap.subscribe((paramMap) => {
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
            }
            else {
                this.typeCreate = true;
                this.postId = null;
                this.heading = 'Create New Post';
            }
        });
    }
    onAddPost(PostForm) {
        if (PostForm.invalid) {
            return;
        }
        if (this.typeCreate) {
            this.postService.addPosts(PostForm.value.enteredName, PostForm.value.enteredDepartment, PostForm.value.enteredPost);
        }
        else {
            this.postService.updatePost(this.postId, PostForm.value.enteredName, PostForm.value.enteredDepartment, PostForm.value.enteredPost);
            PostForm.resetForm();
        }
        PostForm.resetForm();
    }
};
PostCreateComponent = tslib_1.__decorate([
    Component({
        selector: 'app-post-create',
        templateUrl: './post-create.component.html',
        styleUrls: ['./post-create.component.css']
    })
], PostCreateComponent);
export { PostCreateComponent };
//# sourceMappingURL=post-create.component.js.map