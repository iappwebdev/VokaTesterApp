import { Component, OnInit } from '@angular/core';
import { Vokabel } from 'src/app/models/vokabel';
import { VokabelService } from 'src/app/services/vokabel.service';

@Component({
  selector: 'app-uebersicht-gesamt',
  templateUrl: './uebersicht-gesamt.component.html',
  styleUrls: ['./uebersicht-gesamt.component.less']
})
export class UebersichtGesamtComponent implements OnInit {
  vokabeln: Vokabel[] = [];

  constructor(
    private vokabelService: VokabelService
  ) { }

  ngOnInit(): void {
    this.vokabelService
      .all()
      .subscribe(res => {
        this.vokabeln = res;
      });
  }
}
