import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  user: any = null;
  isLogged: boolean = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.user = JSON.parse(
      JSON.parse(JSON.stringify(localStorage.getItem('user')))
    );
    this.isLogged = this.user.email ? true : false;
  }

  onLogout(): void {
    this.authService.logout();
  }

  onLogin() {
    this.router.navigate(['/login']);
  }
}
