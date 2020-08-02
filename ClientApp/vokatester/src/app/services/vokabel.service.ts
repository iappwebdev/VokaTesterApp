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

  byLektion(lektionId: number): Observable<Vokabel[]> {
    return this.http.get<Vokabel[]>(this.path + '/by-lektion/' + lektionId);
  }
}
