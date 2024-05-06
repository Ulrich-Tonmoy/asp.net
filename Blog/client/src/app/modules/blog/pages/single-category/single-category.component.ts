import { Component, DestroyRef, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostsService } from 'src/app/core/services/posts.service';
import { Post } from '@shared/libs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-single-category',
  templateUrl: './single-category.component.html',
  styleUrls: ['./single-category.component.scss'],
})
export class SingleCategoryComponent {
  posts: Post[] = [];
  catName: string = '';
  destroyRef = inject(DestroyRef);

  constructor(
    private route: ActivatedRoute,
    private postService: PostsService
  ) {
    this.route.params.pipe(takeUntilDestroyed()).subscribe((params: any) => {
      this.catName = params['category'];
      this.postService
        .getPostByCategory(params.id)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe((data) => {
          this.posts = data;
        });
    });
  }
}
