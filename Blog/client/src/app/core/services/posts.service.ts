import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Post } from '../models/post';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PostsService {
  baseUrl: string = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private router: Router
  ) {}

  createPost = (post: Post) => {
    this.http
      .post(`${this.baseUrl}/post`, { ...post, categoryId: post.category.id })
      .subscribe(
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
      .get(`${this.baseUrl}/post`)
      .pipe(map((actions: any) => actions.data));
  };

  getPostById = (id: string) => {
    return this.http
      .get(`${this.baseUrl}/post/${id}`)
      .pipe(map((actions: any) => actions.data));
  };

  updatePost = (id: string, post: Post) => {
    this.http
      .patch(`${this.baseUrl}/post`, {
        ...post,
        categoryId: post.category.id,
        id,
      })
      .subscribe(
        (response: any) => {
          console.log(response.data);
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
    this.http.delete(`${this.baseUrl}/post/${id}`).subscribe(
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

  markFeatured = (post: any, isFeatured: boolean) => {
    this.http.patch(`${this.baseUrl}/post`, { ...post, isFeatured }).subscribe(
      (response: any) => {
        console.log(response.data);
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
        `${this.baseUrl}/post?sortBy=createdAt&orderBy=desc&isFeatured=true&limit=4`
      )
      .pipe(map((actions: any) => actions.data));
  };

  getLatestPost = () => {
    return this.http
      .get(`${this.baseUrl}/post?sortBy=createdAt&orderBy=desc&limit=6`)
      .pipe(map((actions: any) => actions.data));
  };

  getSimilarPost = (catId: string, postId: string, limit: number = 4) => {
    return this.http
      .get(
        `${this.baseUrl}/post?idNotEqual=${postId}&categoryId=${catId}&limit=${limit}`
      )
      .pipe(map((actions: any) => actions.data));
  };

  getPostByCategory = (cat: string) => {
    return this.http
      .get(`${this.baseUrl}/post?categoryId=${cat}`)
      .pipe(map((actions: any) => actions.data));
  };

  viewPost = (post: any, views: number) => {
    this.http.patch(`${this.baseUrl}/post`, { ...post, views }).subscribe(
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
