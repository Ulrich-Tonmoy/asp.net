import { Component, DestroyRef, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/core/services/auth.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss'],
})
export class SignUpComponent {
  destroyRef = inject(DestroyRef);

  constructor(
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  public onSubmit(formValue: any) {
    this.authService
      .registration(
        formValue.name,
        formValue.email,
        formValue.password,
        formValue.confirmPassword
      )
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((_response) => {
        this.toastr.success('User Successfully Registered.');
        this.router.navigate(['/login']);
      });
  }
}
