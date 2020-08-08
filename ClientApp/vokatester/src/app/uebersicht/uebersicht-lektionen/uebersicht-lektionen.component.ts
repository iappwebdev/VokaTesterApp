import { Component, OnInit } from '@angular/core';
import { Lektion } from 'src/app/models/lektion';
import { LektionenService } from 'src/app/services/lektionen.service';

@Component({
  selector: 'app-uebersicht-lektionen',
  templateUrl: './uebersicht-lektionen.component.html',
  styleUrls: ['./uebersicht-lektionen.component.less']
})
export class UebersichtLektionenComponent implements OnInit {
  lektionen: Lektion[] = [];

  constructor(
    private lektionenService: LektionenService
  ) { }

  ngOnInit(): void {
    this.lektionenService
      .lektionen()
      .subscribe(res => {
        this.lektionen = res;
      })
  }
  
  getColor(lektion: Lektion): string {
    return this.lektionenService.getColorOverview(lektion);
  }
}
