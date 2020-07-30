import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { AuthService } from '../services/auth.service';

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

  testToastr(): void {
    if (!environment.production) {
      if (this.msgCnt % 2 === 0) {
        this.toastr.success("Das ist eine Success Test Nachricht");
      }
      else {
        this.toastr.error("Das ist eine Error Test Nachricht");
      }
      
      this.msgCnt++;
    }
  }
}
