import { Component, OnInit } from '@angular/core';
import { Lektion } from 'src/app/models/lektion';
import { LektionenService } from 'src/app/services/lektionen.service';

@Component({
  selector: 'app-übersicht-lektionen',
  templateUrl: './übersicht-lektionen.component.html',
  styleUrls: ['./übersicht-lektionen.component.less']
})
export class ÜbersichtLektionenComponent implements OnInit {
  lektionen: Lektion[] = [];

  constructor(
    private lektionenService: LektionenService
  ) { }

  ngOnInit(): void {
    this.lektionenService.lektionen().subscribe(res => {
      this.lektionen = res;
    })
  }
}
