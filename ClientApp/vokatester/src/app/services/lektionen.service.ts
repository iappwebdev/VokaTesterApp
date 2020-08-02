import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lektion } from 'src/app/models/lektion';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LektionenService {
  private path = environment.apiUrl + '/lektionen';

  constructor(
    private http: HttpClient
  ) { }

  lektion(lektionId: number): Observable<Lektion> {
    return this.http.get<Lektion>(this.path + '/' + lektionId);
  }

  lektionen(): Observable<Lektion[]> {
    return this.http.get<Lektion[]>(this.path);
  }
}
