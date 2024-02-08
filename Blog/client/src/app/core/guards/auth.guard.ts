import { Injectable } from '@angular/core';
import { Router, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  constructor(private toastr: ToastrService, public router: Router) {}

  canActivate(): Observable<boolean> | Promise<boolean> | UrlTree | boolean {
    const user = JSON.parse(
      JSON.parse(JSON.stringify(localStorage.getItem('user')))
    )?.email;
    if (!user) {
      this.toastr.warning('Login to Access the dashboard.');
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }
}
