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

  getFortschrittLektion(lektionId: number): Observable<Fortschritt> {
    return this.http.get<Fortschritt>(this.path + '/' + lektionId);
  }

  getFortschrittLektionBereich(lektionId: number, bereichId: number): Observable<Fortschritt> {
    return this.http.get<Fortschritt>(this.path + '/' + lektionId + '/bereich/' + bereichId);
  }

  finishLektion(lektionId: number): Observable<boolean> {
    return this.http.post<boolean>(this.path + '/finish/' + lektionId, {});
  }
  
  finishLektionBereich(lektionId: number, bereichId: number): Observable<boolean> {
    return this.http.post<boolean>(this.path + '/finish/' + lektionId + '/bereich/' + bereichId, {});
  }

  resetFortschrittLektion(lektionId: number): Observable<boolean> {
    return this.http.post<boolean>(this.path + '/reset/' + lektionId, {});
  }
  
  resetFortschrittLektionBereich(lektionId: number, bereichId: number): Observable<boolean> {
    return this.http.post<boolean>(this.path + '/reset/' + lektionId + '/bereich/' + bereichId, {});
  }
}
