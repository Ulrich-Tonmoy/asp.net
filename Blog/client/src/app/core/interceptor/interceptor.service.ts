import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable()
export class InterceptorService implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const toastr = inject(ToastrService);

    const jwt = JSON.parse(
      JSON.parse(JSON.stringify(localStorage.getItem('user')))
    );
    if (jwt?.token != null) {
      let jwtToken = req.clone({
        setHeaders: {
          Authorization: 'Bearer ' + jwt.token,
        },
      });
      return next.handle(jwtToken).pipe(
        catchError((error) => {
          toastr.error(error.error);
          return throwError(() => error);
        })
      );
    }
    return next.handle(req);
  }
}
