import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { BaseHttpService } from '../http/base-http.service';
import { EndpointService } from '../http/endpoint.service';
import { Sub } from '@shared/libs';

@Injectable({
  providedIn: 'root',
})
export class SubService {
  constructor(private baseHttp: BaseHttpService) {}

  public addSub(sub: Sub): Observable<any> {
    return this.baseHttp.post(EndpointService.subscription, sub);
  }

  public checkSubscription(email: string): Observable<any> {
    return this.baseHttp
      .get(`${EndpointService.subscriptionAny}?email=${email}`)
      .pipe(map((actions: any) => actions.data));
  }

  public getSubs(): Observable<any> {
    return this.baseHttp
      .get(EndpointService.subscription)
      .pipe(map((actions: any) => actions.data));
  }

  public deleteSub(id: string): Observable<any> {
    return this.baseHttp.delete(
      EndpointService.subscription.replace('{id}', id)
    );
  }
}
