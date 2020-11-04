import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { jsFileDownloader } from 'js-client-file-downloader';
let PostPlacedComponent = class PostPlacedComponent {
    constructor(postService, authService) {
        this.postService = postService;
        this.authService = authService;
        this.posts = [];
        this.userisAuthenticated = false;
    }
    ngOnInit() {
        this.postService.getPosts();
        this.postsSubscription = this.postService.getPostUpdateListener()
            .subscribe((posts) => {
            this.posts = posts;
        });
        this.userisAuthenticated = this.authService.getIsAuth();
        this.authStatusSubscription = this.authService
            .getAuthStatusListener()
            .subscribe(isAuthenticated => {
            this.userisAuthenticated = isAuthenticated;
        });
    }
    onDownload(postID) {
        this.postService.getPost(postID).subscribe(postData => {
            const post = {
                id: postData._id,
                Name: postData.Name,
                Department: postData.Department,
                PlacedPost: postData.PlacedPost
            };
            const heading = 'APDS GOVERNMENT POST';
            const postInfo = heading + '\n\n' + 'Post ID: ' + post.id + '\n\n'
                + 'Post Name: ' + post.Name + '\n\n'
                + 'Department: ' + post.Department + '\n\n'
                + 'Post Information: ' + post.PlacedPost;
            jsFileDownloader.makeSimplePDF(postInfo, post.id);
        });
    }
    onDelete(postID) {
        this.postService.deletePost(postID);
    }
    ngOnDestroy() {
        this.postsSubscription.unsubscribe();
    }
};
PostPlacedComponent = tslib_1.__decorate([
    Component({
        selector: 'app-post-placed',
        templateUrl: './post-placed.component.html',
        styleUrls: ['./post-placed.component.css']
    })
], PostPlacedComponent);
export { PostPlacedComponent };
//# sourceMappingURL=post-placed.component.js.map