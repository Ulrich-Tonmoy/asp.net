import { Component } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  constructor(
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  public onSubmit(formValue: any) {
    this.authService
      .login(formValue.email, formValue.password)
      .pipe(takeUntilDestroyed())
      .subscribe((response: any) => {
        this.toastr.success('Successfully Logged In.');
        localStorage.setItem('user', JSON.stringify(response.data));
        this.router.navigate(['/dashboard']);
      });
  }
}
