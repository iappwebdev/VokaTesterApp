import { Component, OnInit } from '@angular/core';
import { Lektion } from 'src/app/models/lektion';
import { LektionenService } from 'src/app/services/lektionen.service';

@Component({
  selector: 'app-lernen-lektionen',
  templateUrl: './lernen-lektionen.component.html',
  styleUrls: ['./lernen-lektionen.component.less']
})
export class LernenLektionenComponent implements OnInit {
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
