import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { BaseHttpService } from '../http/base-http.service';
import { EndpointService } from '../http/endpoint.service';
import { Post } from '@shared/libs';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PostsService {
  constructor(private baseHttp: BaseHttpService) {}

  public createPost(post: Post): Observable<any> {
    return this.baseHttp.post(EndpointService.post, {
      ...post,
      categoryId: post.category.id,
    });
  }

  public getPosts(): Observable<any> {
    return this.baseHttp
      .get(EndpointService.post)
      .pipe(map((actions: any) => actions.data));
  }

  public getPostById(id: string): Observable<any> {
    return this.baseHttp
      .get(EndpointService.postById.replace('{id}', id))
      .pipe(map((actions: any) => actions.data));
  }

  public updatePost(id: string, post: Post): Observable<any> {
    return this.baseHttp.put(EndpointService.post, {
      ...post,
      categoryId: post.category.id,
      id,
    });
  }

  public deletePost(id: string, title: string): Observable<any> {
    return this.baseHttp.delete(EndpointService.postById.replace('{id}', id));
  }

  public markFeatured(post: any, isFeatured: boolean): Observable<any> {
    return this.baseHttp.put(EndpointService.post, { ...post, isFeatured });
  }

  public getFeaturedPost(): Observable<any> {
    return this.baseHttp
      .get(
        `${EndpointService.post}?sortBy=createdAt&orderBy=desc&isFeatured=true&limit=4`
      )
      .pipe(map((actions: any) => actions.data));
  }

  public getLatestPost(): Observable<any> {
    return this.baseHttp
      .get(`${EndpointService.post}?sortBy=createdAt&orderBy=desc&limit=6`)
      .pipe(map((actions: any) => actions.data));
  }

  public getSimilarPost(
    catId: string,
    postId: string,
    limit: number = 4
  ): Observable<any> {
    return this.baseHttp
      .get(
        `${EndpointService.post}?idNotEqual=${postId}&categoryId=${catId}&limit=${limit}`
      )
      .pipe(map((actions: any) => actions.data));
  }

  public getPostByCategory(cat: string): Observable<any> {
    return this.baseHttp
      .get(`${EndpointService.post}?categoryId=${cat}`)
      .pipe(map((actions: any) => actions.data));
  }

  public viewPost(post: any, views: number): Observable<any> {
    return this.baseHttp.put(EndpointService.post, { ...post, views });
  }
}
