import { Component } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss'],
})
export class SignUpComponent {
  constructor(private authService: AuthService) {}

  onSubmit(formValue: any) {
    this.authService.signup(
      formValue.name,
      formValue.email,
      formValue.password
    );
  }
}
