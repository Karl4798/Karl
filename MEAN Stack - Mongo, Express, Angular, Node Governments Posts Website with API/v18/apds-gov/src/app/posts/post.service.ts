import { Post } from './post.model';
import { Injectable, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({providedIn: 'root'})
export class PostsService {

  // Constructor with required injections
  constructor(private http: HttpClient, private router: Router) {}

  // Variables used to store posts information
  private posts: Post [] = [];
  private updatedPosts = new Subject<Post[]>();

  // Method used to get single (selected) post from the server
  getPost(id: string) {
    return this.http.get<{
      _id: string;
      Name: string,
      Department: string,
      PlacedPost: string,
    }>('/api/posts/' + id);
  }

  // Method used to get all posts from the server
  getPosts() {
    this.http.get<{message: string, posts: any}>('/api/posts')
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

  // Method used to get updatePosts listener
  getPostUpdateListener() {
    return this.updatedPosts.asObservable();
  }

  // Method used to add a post to the database
  addPosts(Name: string, Department: string, PlacedPost: string) {
    const post: Post = { id: null, Name, Department, PlacedPost };
    this.http.post<{message: string, postId: string}>('/api/posts', post)
    .subscribe((responsePostData) => {
      console.log(responsePostData.message);
      const id = responsePostData.postId;
      post.id = id;
      this.posts.push(post);
      this.updatedPosts.next([...this.posts]);
      this.router.navigate(['/posts']);
    });

  }

  // Method used to update an existing post in the database
  updatePost(id: string, Name: string, Department: string, PlacedPost: string ) {
    const post: Post = { id, Name, Department, PlacedPost };
    this.http.put('/api/posts/' + id, post)
      .subscribe(response => {
        const updatedPosts = [...this.posts];
        const oldPostIndex = updatedPosts.findIndex(p => p.id === post.id);
        updatedPosts[oldPostIndex] = post;
        this.posts = updatedPosts;
        this.updatedPosts.next([...this.posts]);
        this.router.navigate(['/posts']);
      });
  }

  // Method used to delete a post from the database
  deletePost(postID: string) {
    this.http.delete('/api/posts/' + postID)
    .subscribe(() => {
      const updatePostsDel = this.posts.filter(post => post.id !== postID);
      this.posts = updatePostsDel;
      this.updatedPosts.next([...this.posts]);
      console.log('Post Deleted');
    });
  }

}
