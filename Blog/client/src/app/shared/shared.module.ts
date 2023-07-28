import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './auth/login/login.component';
import { HeaderComponent } from './layouts/header/header.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [LoginComponent, HeaderComponent, FooterComponent],
  imports: [CommonModule, FormsModule, RouterModule],
  exports: [LoginComponent, HeaderComponent, FooterComponent],
})
export class SharedModule {}
