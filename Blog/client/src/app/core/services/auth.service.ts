import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl: string = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private router: Router
  ) {}

  login(email: string, password: string) {
    this.http
      .post(`${this.baseUrl}/user/login`, { email, password })
      .pipe(map((actions: any) => actions))
      .subscribe(
        (response: any) => {
          this.toastr.success('Successfully Logged In.');
          localStorage.setItem('user', JSON.stringify(response.data));
          this.router.navigate(['/dashboard']);
        },
        (error: any) => {
          this.toastr.error(error.error);
        }
      );
  }

  signup(name: string, email: string, password: string) {
    this.http
      .post(`${this.baseUrl}/user/register`, { name, email, password })
      .pipe(map((actions: any) => actions))
      .subscribe(
        (response: any) => {
          this.toastr.success('User Successfully Registered.');
          this.router.navigate(['/login']);
        },
        (error: any) => {
          this.toastr.error(error.error);
        }
      );
  }

  logout() {
    this.toastr.success('Successfully Logged Out.');
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
