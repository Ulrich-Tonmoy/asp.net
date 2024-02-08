import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  user: any = null;
  isLogged: boolean = false;

  constructor(private toastr: ToastrService, private router: Router) {}

  ngOnInit(): void {
    this.user = JSON.parse(
      JSON.parse(JSON.stringify(localStorage.getItem('user')))
    );
    this.isLogged = this.user.email ? true : false;
  }

  public onLogout(): void {
    this.toastr.success('Successfully Logged Out.');
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  public onLogin() {
    this.router.navigate(['/login']);
  }
}
