import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/post';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-all-post',
  templateUrl: './all-post.component.html',
  styleUrls: ['./all-post.component.scss'],
})
export class AllPostComponent implements OnInit {
  posts: Array<Post> = [];

  constructor(private postService: PostsService) {}

  ngOnInit(): void {
    this.getAllPosts();
  }

  onDelete(id: any, title: string): void {
    if (confirm(`Do you want to delete the post '${title}'?`)) {
      this.postService.deletePost(id.toString(), title);
      this.getAllPosts();
    }
  }

  getAllPosts() {
    this.postService.getPosts().subscribe((data) => {
      this.posts = data;
    });
  }

  onFeatured(id: any, isFeatured: boolean) {
    this.postService.markFeatured(id, isFeatured);
    this.getAllPosts();
  }
}
