import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AuthService } from 'src/app/services/infrastructure/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(
    private router: Router,
    private authService: AuthService,
    private toastrService: ToastrService
  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(1),
      catchError((err) => {
        let message = '';
        let returnToHome = false;
        
        if (err.status === 401) {
          message = 'Die Sitzung ist abgelaufen, bitte erneut einloggen.';
          this.authService.removeToken();
          this.router.navigate(['login']);
        }
        else if (err.status === 403) {
          message = 'Keine Berechtigung.';
          returnToHome = true;
        }
        else if (err.status === 404) {
          message = 'Seite nicht gefunden.';
          returnToHome = true;
        }
        else if (err.status === 400) {
          message = 'Client-Fehler.';
        }
        else if (err.status === 0) {
          message = 'Konnte keine Verbindung zum Server herstellen.';
        }
        else {
          //global message for error
          console.log('ErrorInterceptorService -> err', err)
          message = 'Ein unbekannter Fehler ist aufgetreten.';
        }

        this.toastrService.error(message, 'Fehler');
        if (returnToHome) this.router.navigate(['home-vokabeln']);
        return throwError(err)
      })
    );
  }
}