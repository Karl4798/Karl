import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
let PostsService = class PostsService {
    constructor(http, router) {
        this.http = http;
        this.router = router;
        this.posts = [];
        this.updatedPosts = new Subject();
    }
    getPost(id) {
        return this.http.get('https://localhost:3000/api/posts/' + id);
    }
    getPosts() {
        this.http.get('https://localhost:3000/api/posts')
            .pipe(map((postData) => {
            return postData.posts.map(post => {
                return {
                    Name: post.Name,
                    Department: post.Department,
                    PlacedPost: post.PlacedPost,
                    id: post._id
                };
            });
        }))
            .subscribe((changedPosts) => {
            this.posts = changedPosts;
            this.updatedPosts.next([...this.posts]);
        });
    }
    getPostUpdateListener() {
        return this.updatedPosts.asObservable();
    }
    addPosts(Name, Department, PlacedPost) {
        const post = { id: null, Name, Department, PlacedPost };
        this.http.post('https://localhost:3000/api/posts', post)
            .subscribe((responsePostData) => {
            console.log(responsePostData.message);
            const id = responsePostData.postId;
            post.id = id;
            this.posts.push(post);
            this.updatedPosts.next([...this.posts]);
            this.router.navigate(['/posts']);
        });
    }
    updatePost(id, Name, Department, PlacedPost) {
        const post = { id, Name, Department, PlacedPost };
        this.http
            .put('https://localhost:3000/api/posts/' + id, post)
            .subscribe(response => {
            const updatedPosts = [...this.posts];
            const oldPostIndex = updatedPosts.findIndex(p => p.id === post.id);
            updatedPosts[oldPostIndex] = post;
            this.posts = updatedPosts;
            this.updatedPosts.next([...this.posts]);
            this.router.navigate(['/posts']);
        });
    }
    deletePost(postID) {
        this.http.delete('https://localhost:3000/api/posts/' + postID)
            .subscribe(() => {
            const updatePostsDel = this.posts.filter(post => post.id !== postID);
            this.posts = updatePostsDel;
            this.updatedPosts.next([...this.posts]);
            console.log('Post Deleted');
        });
    }
};
PostsService = tslib_1.__decorate([
    Injectable({ providedIn: 'root' })
], PostsService);
export { PostsService };
//# sourceMappingURL=post.service.js.map