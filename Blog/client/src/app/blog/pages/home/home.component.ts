import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/core/models/post';
import { PostsService } from 'src/app/core/services/posts.service';

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
    this.postService.getFeaturedPost().subscribe((data) => {
      this.featuredPost = data;
    });

    this.postService.getLatestPost().subscribe((data) => {
      this.latestPost = data;
    });
  }
}
