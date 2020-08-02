import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckResult } from 'src/app/models/check-result';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TrainierenService {
  private path = environment.apiUrl + '/trainieren';

  constructor(
    private http: HttpClient
  ) { }

  checkAnswer(vokabelId: number, answer: string): Observable<CheckResult> {
    return this.http.post<CheckResult>(this.path, { vokabelId, answer });
  }
}
