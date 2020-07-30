import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lektion } from '../models/lektion';
import { Vokabel } from '../models/vokabel';

@Injectable({
  providedIn: 'root'
})
export class LernenService {
  private path = environment.apiUrl + '/lernen';

  constructor(
    private http: HttpClient
  ) { }

  lektion(lektionId: number): Observable<Lektion> {
    return this.http.get<Lektion>(this.path + '/lektionen/' + lektionId);
  }

  lektionen(): Observable<Lektion[]> {
    return this.http.get<Lektion[]>(this.path + '/lektionen');
  }

  byLektion(lektionId: number): Observable<Vokabel[]> {
    return this.http.get<Vokabel[]>(this.path + '/vokabeln-by-lektion/' + lektionId);
  }
}
