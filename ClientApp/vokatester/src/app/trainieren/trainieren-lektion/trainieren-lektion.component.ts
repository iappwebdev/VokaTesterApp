import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Lektion } from 'src/app/models/lektion';
import { Vokabel } from 'src/app/models/vokabel';
import { LektionenService } from 'src/app/services/lektionen.service';
import { VokabelService } from 'src/app/services/vokabel.service';

@Component({
  selector: 'app-trainieren-lektion',
  templateUrl: './trainieren-lektion.component.html',
  styleUrls: ['./trainieren-lektion.component.less']
})
export class TrainierenLektionComponent implements OnInit {
  private idx: number = 0;
  private srcVokabeln: Vokabel[] = [];

  lektion!: Lektion;

  constructor(
    private route: ActivatedRoute,
    private lektionenService: LektionenService,
    private vokabelService: VokabelService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let lektionId: number = parseInt(params.get('id')!)

      this.lektionenService.lektion(lektionId).subscribe(res => {
        this.lektion = res;
      });

      this.vokabelService.byLektion(lektionId).subscribe(res => {
        this.srcVokabeln = res;
      });
    });
  }

  get currentVokabel(): Vokabel | null {
    if (!this.srcVokabeln?.length) return null;
    return this.srcVokabeln[this.idx];
  }

  get inhalt(): string | undefined {
    if (!this.lektion) return;
    return `${this.lektion.inhalt}`;
  }

  get subTitle(): string | undefined {
    if (!this.lektion) return;
    return `${this.lektion.subTitel}`;
  }

  get title(): string | undefined {
    if (!this.lektion) return;
    return `${this.lektion.name} - ${this.lektion.titel}`;
  }

  proceed(): void {
    this.idx++;
  }
}
