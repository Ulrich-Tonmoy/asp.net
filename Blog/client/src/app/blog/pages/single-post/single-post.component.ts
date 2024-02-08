import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from '@shared/libs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.scss'],
})
export class SinglePostComponent implements OnInit {
  post: any = null;
  similarPost: Array<Post> = [];

  constructor(
    private route: ActivatedRoute,
    private postService: PostsService
  ) {}

  ngOnInit(): void {
    this.route.params.pipe(takeUntilDestroyed()).subscribe((params: any) => {
      this.postService
        .getPostById(params.id)
        .pipe(takeUntilDestroyed())
        .subscribe((data) => {
          this.postService
            .viewPost(data, data.views + 1)
            .pipe(takeUntilDestroyed())
            .subscribe((_response: any) => {});
          this.post = data;
          this.post.views = data.views + 1;

          this.postService
            .getSimilarPost(data.category.id, data.id)
            .pipe(takeUntilDestroyed())
            .subscribe((data) => {
              this.similarPost = data;
            });
        });
    });
  }
}
