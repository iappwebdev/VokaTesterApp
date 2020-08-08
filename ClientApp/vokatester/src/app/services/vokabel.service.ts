import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vokabel } from 'src/app/models/vokabel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VokabelService {
  private path = environment.apiUrl + '/vokabeln';

  constructor(
    private http: HttpClient
  ) { }

  all(): Observable<Vokabel[]> {
    return this.http.get<Vokabel[]>(this.path);
  }

  byLektion(lektionId: number): Observable<Vokabel[]> {
    return this.http.get<Vokabel[]>(this.path + '/lektion/' + lektionId);
  }

  byLektionBereich(lektionId: number, bereichId: number): Observable<Vokabel[]> {
    return this.http.get<Vokabel[]>(this.path + '/lektion/' + lektionId + '/bereich/' + bereichId);
  }

  previousBySimilarity(vokabelId: number, pattern: string, prev?: string, next?: string): Observable<Vokabel[]> {
    const data = { vokabelId, pattern, prev, next };
    return this.http.post<Vokabel[]>(this.path + '/previous-with-similarity', data);
  }
}
