import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { BaseHttpService } from '../http/base-http.service';
import { EndpointService } from '../http/endpoint.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private baseHttp: BaseHttpService) {}

  public login(email: string, password: string): Observable<any> {
    return this.baseHttp
      .post(EndpointService.login, { email, password })
      .pipe(map((actions: any) => actions));
  }

  public registration(
    name: string,
    email: string,
    password: string,
    confirmPassword: string
  ): Observable<any> {
    return this.baseHttp
      .post(EndpointService.registration, {
        name,
        email,
        password,
        confirmPassword,
      })
      .pipe(map((actions: any) => actions));
  }
}
