import { HttpClient, HttpParams } from '@angular/common/http';
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

  byLektion(lektionId: number): Observable<Vokabel[]> {
    return this.http.get<Vokabel[]>(this.path + '/by-lektion/' + lektionId);
  }

  previousBySimilarity(vokabelId: number, pattern: string): Observable<Vokabel[]> {
    return this.http.get<Vokabel[]>(this.path + '/previous-by-similarity', {
      params: new HttpParams()
        .set('vokabelId', vokabelId.toString())
        .set('pattern', pattern)
    });
  }
}
