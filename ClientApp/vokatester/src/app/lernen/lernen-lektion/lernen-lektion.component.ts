import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Vokabel } from 'src/app/models/vokabel';
import { Lektion } from '../../models/lektion';
import { LernenService } from '../../services/lernen.service';

@Component({
  selector: 'app-lernen-lektion',
  templateUrl: './lernen-lektion.component.html',
  styleUrls: ['./lernen-lektion.component.less']
})
export class LernenLektionComponent implements OnInit {
  lektionId: number;
  lektion?: Lektion;
  vokabeln: Vokabel[] = [];

  constructor(
    private route: ActivatedRoute,
    private lernenService: LernenService) {
      this.lektionId = this.route.snapshot.params.id;
      console.log("LernenLektionComponent -> this.lektionId", this.lektionId)
      this.lernenService.lektion(this.lektionId).subscribe(res => {
        this.lektion = res;
      });
      this.lernenService.byLektion(this.lektionId).subscribe(res => {
        this.vokabeln = res;
      })
     }

  ngOnInit(): void {
  }

}
