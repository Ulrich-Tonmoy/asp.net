import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private router: Router
  ) {}

  login(email: string, password: string) {
    this.http
      .get(`http://localhost:3000/users?email=${email}`)
      .pipe(map((actions: any) => actions))
      .subscribe((user: Array<any>) => {
        if (user.length > 0) {
          if (user[0].password === password) {
            this.toastr.success('Successfully Logged In.');
            localStorage.setItem('user', JSON.stringify(user[0]));
            this.router.navigate(['/dashboard']);
          } else {
            this.toastr.warning('Wrong password.');
          }
        } else {
          this.toastr.error(`User with email: '${email}' not found.`);
        }
      });
  }

  logout() {
    this.toastr.success('Successfully Logged Out.');
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
