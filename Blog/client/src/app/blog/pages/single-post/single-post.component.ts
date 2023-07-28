import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from 'src/app/models/post';
import { PostsService } from 'src/app/services/posts.service';

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
    this.route.params.subscribe((params: any) => {
      this.postService.getPostById(params.id).subscribe((data) => {
        this.postService.viewPost(data.id, data.views + 1);
        this.post = data;
        this.post.views = data.views + 1;

        this.postService
          .getSimilarPost(data.category.id, data.id)
          .subscribe((data) => {
            this.similarPost = data;
          });
      });
    });
  }
}
