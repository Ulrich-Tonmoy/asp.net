import { Component, DestroyRef, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  public loginForm: FormGroup = new FormGroup('');

  private destroyRef = inject(DestroyRef);

  constructor(
    private authService: AuthService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  public onSubmit() {
    const loginInfo = this.loginForm.value;
    this.authService
      .login(loginInfo.email, loginInfo.password)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((response: any) => {
        this.toastr.success('Successfully Logged In.');
        localStorage.setItem('user', JSON.stringify(response.data));
        this.router.navigate(['/dashboard']);
      });
  }
}
