import { Component, OnInit } from '@angular/core';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from '@shared/libs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-all-post',
  templateUrl: './all-post.component.html',
  styleUrls: ['./all-post.component.scss'],
})
export class AllPostComponent implements OnInit {
  posts: Array<Post> = [];

  constructor(
    private postService: PostsService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getAllPosts();
  }

  public onDelete(id: any, title: string): void {
    if (confirm(`Do you want to delete the post '${title}'?`)) {
      this.postService
        .deletePost(id.toString(), title)
        .pipe(takeUntilDestroyed())
        .subscribe((_response: any) => {
          this.toastr.warning(`Post '${title}' deleted successfully!`);
        });
      this.getAllPosts();
    }
  }

  public getAllPosts() {
    this.postService
      .getPosts()
      .pipe(takeUntilDestroyed())
      .subscribe((data) => {
        this.posts = data;
      });
  }

  public onFeatured(post: any, isFeatured: boolean) {
    this.postService
      .markFeatured(post, isFeatured)
      .pipe(takeUntilDestroyed())
      .subscribe((_response: any) => {
        this.toastr.success(
          `Post ${isFeatured ? 'is now Featured' : 'Featured removed'}!`
        );
        this.router.navigate(['dashboard/posts']);
      });
    this.getAllPosts();
  }
}
