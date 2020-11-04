import { Component, OnInit, OnDestroy } from '@angular/core';
import { Post } from '../post.model';
import { PostsService } from '../post.service';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { jsFileDownloader } from 'js-client-file-downloader';
import { Router } from '@angular/router';


@Component({
  selector: 'app-post-placed',
  templateUrl: './post-placed.component.html',
  styleUrls: ['./post-placed.component.css']
})

export class PostPlacedComponent implements OnInit, OnDestroy {

  // Variables used to store post information
  posts: Post [] = [];
  userisAuthenticated = false;
  private authStatusSubscription: Subscription;
  private postsSubscription: Subscription;

  // Constructor with required injections
  constructor(public postService: PostsService, private authService: AuthService, private router: Router) {}

  // Method used to initialize the posts class
  ngOnInit() {
    this.postService.getPosts();
    this.postsSubscription = this.postService.getPostUpdateListener()
    .subscribe((posts: Post[]) => {
      this.posts = posts;
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

  // Method used to handle the onDownload button click event
  onDownload(postID: string) {

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

  // Method used to handle the onDelete button click event
  onDelete(postID: string) {
    this.postService.deletePost(postID);
  }

  // Method used to handle the onEdit button click event
  onEdit(postID: string) {
    this.router.navigate(['/edit/' + postID]);
  }

  ngOnDestroy() {
    this.postsSubscription.unsubscribe();
  }

}
