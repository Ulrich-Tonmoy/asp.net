import { Component, OnInit } from '@angular/core';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from '@shared/libs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  featuredPost: Array<Post> = [];
  latestPost: Array<Post> = [];

  constructor(private postService: PostsService) {}

  ngOnInit(): void {
    this.postService
      .getFeaturedPost()
      .pipe(takeUntilDestroyed())
      .subscribe((data) => {
        this.featuredPost = data;
      });

    this.postService
      .getLatestPost()
      .pipe(takeUntilDestroyed())
      .subscribe((data) => {
        this.latestPost = data;
      });
  }
}
