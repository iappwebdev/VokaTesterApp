import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Vokabel } from '../models/vokabel';

@Injectable({
  providedIn: 'root'
})
export class VokabelService {
  private vokabelPath = environment.apiUrl + '/vokabel'
  constructor(private http: HttpClient) { }

  create(data: Vokabel): Observable<Vokabel> {
    return this.http.post<Vokabel>(this.vokabelPath, data);
  }
}
