import { Component, OnInit } from '@angular/core';
import { Lektion } from '../../models/lektion';
import { LernenService } from '../../services/lernen.service';

@Component({
  selector: 'app-lernen-lektionen',
  templateUrl: './lernen-lektionen.component.html',
  styleUrls: ['./lernen-lektionen.component.less']
})
export class LernenLektionenComponent implements OnInit {
  lektionen: Lektion[] = [];
  constructor(private lernenService: LernenService) { }

  ngOnInit(): void {
    this.lernenService.lektionen().subscribe(res => {
      this.lektionen = res;
    })
  }
}
