import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/infrastructure/auth.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.less']
})
export class NavigationComponent {
  msgCnt: number = 0;

  constructor(
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router
  ) { }

  isLoggedIn(): boolean {
    return this.authService.isAuthenticated();

  }

  logout(): void {
    this.authService.removeToken();
    this.toastr.success('Sie wurden erfolgreich ausgeloggt.');
    this.router.navigate(['login']);
  }
}
