import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestResult } from 'src/app/models/test-result';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TestResultsService {
  private path = environment.apiUrl + '/test-results';

  constructor(
    private http: HttpClient
  ) { }

  all(): Observable<TestResult[]> {
    return this.http.get<TestResult[]>(this.path);
  }

  byLektion(lektionId: number): Observable<TestResult[]> {
    return this.http.get<TestResult[]>(this.path + '/lektion/' + lektionId);
  }

  byLektionBereich(lektionId: number, bereichId: number): Observable<TestResult[]> {
    return this.http.get<TestResult[]>(this.path + '/lektion/' + lektionId + '/bereich/' + bereichId);
  }
}
