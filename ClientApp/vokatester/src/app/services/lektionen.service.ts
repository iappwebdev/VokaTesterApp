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

  // lektion(lektionId: number): Observable<Lektion> {
  //   return this.http.get<Lektion>(this.path + '/' + lektionId);
  // }

  getColorOverview(lektion: Lektion) {
    const red = 140 + ((lektion.id - 1) * 10);
    const green = 140 + ((lektion.id - 1) * 10);
    const blue = 0 + ((lektion.id - 1) * 10);
    return `rgba(${red}, ${green}, ${blue}, 0.8)`;
  }

  getColorTrain(lektion: Lektion) {
    const red = 0 + ((lektion.id - 1) * 20);
    const green = 100 + ((lektion.id - 1) * 15);
    const blue = 250 - ((lektion.id - 1) * 25);
    return `rgba(${red}, ${green}, ${blue}, 0.7)`;
  }

  lektion(lektionKey: string): Observable<Lektion> {
    return this.http.get<Lektion>(this.path + '/' + lektionKey);
  }

  lektionen(): Observable<Lektion[]> {
    return this.http.get<Lektion[]>(this.path);
  }
}
