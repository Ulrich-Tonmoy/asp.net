import { Component, DestroyRef, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/core/services/auth.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss'],
})
export class SignUpComponent {
  public signupForm: FormGroup = new FormGroup('');

  private destroyRef = inject(DestroyRef);

  constructor(
    private authService: AuthService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.signupForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: [
        '',
        [Validators.required, Validators.minLength(6)],
        this.confirmPasswordValidator,
      ],
    });
  }

  public onSubmit() {
    const signupInfo = this.signupForm.value;
    this.authService
      .registration(
        signupInfo.name,
        signupInfo.email,
        signupInfo.password,
        signupInfo.confirmPassword
      )
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((_response) => {
        this.toastr.success('User Successfully Registered.');
        this.router.navigate(['/login']);
      });
  }

  private confirmPasswordValidator(control: FormGroup) {
    const password = control.root.value['password'];
    const confirmPassword = control.value;

    console.log(password, confirmPassword);

    if (password !== confirmPassword) {
      return Promise.resolve({ mismatch: true });
    }

    return Promise.resolve(null);
  }
}
