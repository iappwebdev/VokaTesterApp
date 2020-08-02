import { Component, OnInit } from '@angular/core';
import { Lektion } from 'src/app/models/lektion';
import { LektionenService } from 'src/app/services/lektionen.service';

@Component({
  selector: 'app-trainieren-lektionen',
  templateUrl: './trainieren-lektionen.component.html',
  styleUrls: ['./trainieren-lektionen.component.less']
})
export class TrainierenLektionenComponent implements OnInit {
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
