import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fortschritt } from 'src/app/models/fortschritt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FortschrittService {
  private path = environment.apiUrl + '/fortschritt';

  constructor(
    private http: HttpClient
  ) { }

  getFortschritt(lektionId: number): Observable<Fortschritt> {
    return this.http.get<Fortschritt>(this.path + '/' + lektionId);
  }

  resetFortschritt(lektionId: number): Observable<boolean> {
    return this.http.post<boolean>(this.path + '/reset/' + lektionId, {});
  }
}
