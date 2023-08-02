import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class InterceptorService implements HttpInterceptor {
  constructor() {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const jwt = JSON.parse(
      JSON.parse(JSON.stringify(localStorage.getItem('user')))
    );
    if (jwt?.token != null) {
      let jwtToken = req.clone({
        setHeaders: {
          Authorization: 'Bearer ' + jwt.token,
        },
      });
      return next.handle(jwtToken);
    } else return next.handle(req);
  }
}
