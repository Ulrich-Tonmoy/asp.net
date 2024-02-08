import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { BaseHttpService } from '../http/base-http.service';
import { EndpointService } from '../http/endpoint.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  constructor(private baseHttp: BaseHttpService) {}

  public createCategory(name: string): Observable<any> {
    return this.baseHttp.post(EndpointService.category, { name });
  }

  public getCategories(): Observable<any> {
    return this.baseHttp
      .get(EndpointService.category)
      .pipe(map((actions: any) => actions.data));
  }

  public updateCategory(id: string, name: string): Observable<any> {
    return this.baseHttp.put(EndpointService.category, { id, name });
  }

  public deleteCategory(id: string): Observable<any> {
    return this.baseHttp.delete(
      EndpointService.categoryById.replace('{id}', id)
    );
  }
}
