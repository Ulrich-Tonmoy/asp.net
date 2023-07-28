import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Post } from '../models/post';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class PostsService {
  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private router: Router
  ) {}

  createPost = (post: Post) => {
    this.http.post('http://localhost:3000/posts', post).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.success(`Post ${post.title} added successfully!`);
        this.router.navigate(['dashboard/posts']);
      },
      (error: any) => {
        this.toastr.error('Error occurred creating post!');
        this.toastr.error(error);
      }
    );
  };

  getPosts = () => {
    return this.http
      .get('http://localhost:3000/posts')
      .pipe(map((actions: any) => actions));
  };

  getPostById = (id: string) => {
    return this.http
      .get(`http://localhost:3000/posts/${id}`)
      .pipe(map((actions: any) => actions));
  };

  updatePost = (id: string, post: Post) => {
    this.http.put(`http://localhost:3000/posts/${id}`, { ...post }).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.success(`Post ${post.title} updated successfully!`);
        this.router.navigate(['dashboard/posts']);
      },
      (error: any) => {
        this.toastr.error('Error occurred updating post!');
        this.toastr.error(error);
      }
    );
  };

  deletePost = (id: string, title: string) => {
    this.http.delete(`http://localhost:3000/posts/${id}`).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.warning(`Post '${title}' deleted successfully!`);
      },
      (error: any) => {
        this.toastr.error('Error occurred deleting post!');
        this.toastr.error(error);
      }
    );
  };

  markFeatured = (id: string, isFeatured: boolean) => {
    this.http
      .patch(`http://localhost:3000/posts/${id}`, { isFeatured })
      .subscribe(
        (response: any) => {
          console.log(response);
          this.toastr.success(
            `Post ${isFeatured ? 'is now Featured' : 'Featured removed'}!`
          );
          this.router.navigate(['dashboard/posts']);
        },
        (error: any) => {
          this.toastr.error('Error occurred updating post!');
          this.toastr.error(error);
        }
      );
  };

  getFeaturedPost = () => {
    return this.http
      .get(
        `http://localhost:3000/posts?_sort=createdAt&_order=desc&isFeatured=true&_limit=4`
      )
      .pipe(map((actions: any) => actions));
  };

  getLatestPost = () => {
    return this.http
      .get(`http://localhost:3000/posts?_sort=createdAt&_order=desc&_limit=6`)
      .pipe(map((actions: any) => actions));
  };

  getSimilarPost = (catId: string, postId: string, limit: number = 4) => {
    return this.http
      .get(
        `http://localhost:3000/posts?id_ne=${postId}&category.id=${catId}&_limit=${limit}`
      )
      .pipe(map((actions: any) => actions));
  };

  getPostByCategory = (cat: string) => {
    return this.http
      .get(`http://localhost:3000/posts?category.id=${cat}`)
      .pipe(map((actions: any) => actions));
  };

  viewPost = (id: string, views: number) => {
    this.http.patch(`http://localhost:3000/posts/${id}`, { views }).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.success(`Post Vew count updated!`);
      },
      (error: any) => {
        this.toastr.error('Error occurred updating post!');
        this.toastr.error(error);
      }
    );
  };
}
