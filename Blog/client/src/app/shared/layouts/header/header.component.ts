import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  email: string = '';
  isLogged: boolean = false;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.email = JSON.parse(
      JSON.parse(JSON.stringify(localStorage.getItem('user')))
    ).email;
    this.isLogged = this.email ? true : false;
  }

  onLogout(): void {
    this.authService.logout();
  }
}
