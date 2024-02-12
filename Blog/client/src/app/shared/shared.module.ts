import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './auth/login/login.component';
import { HeaderComponent } from './layouts/header/header.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SignUpComponent } from './auth/sign-up/sign-up.component';

@NgModule({
  declarations: [
    LoginComponent,
    HeaderComponent,
    FooterComponent,
    SignUpComponent,
  ],
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  exports: [LoginComponent, HeaderComponent, FooterComponent],
})
export class SharedModule {}
