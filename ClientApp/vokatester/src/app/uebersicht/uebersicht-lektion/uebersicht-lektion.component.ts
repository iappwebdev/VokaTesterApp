import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Lektion } from 'src/app/models/lektion';
import { Vokabel } from 'src/app/models/vokabel';
import { LektionenService } from 'src/app/services/lektionen.service';
import { VokabelService } from 'src/app/services/vokabel.service';

@Component({
  selector: 'app-uebersicht-lektion',
  templateUrl: './uebersicht-lektion.component.html',
  styleUrls: ['./uebersicht-lektion.component.less']
})
export class UebersichtLektionComponent implements OnInit {
  vokabeln: Vokabel[] = [];
  lektion!: Lektion;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private lektionenService: LektionenService,
    private vokabelService: VokabelService
  ) { }

  ngOnInit(): void {
    this.route.paramMap
      .subscribe(params => {
        let lektionKey: string = params.get('lektionKey')!;

        this.lektionenService
          .lektion(lektionKey)
          .subscribe(res => {
            if (res === null) {
              this.router.navigate(['home-vokabeln'])
            }

            this.lektion = res;
            
            this.vokabelService
            .byLektion(this.lektion.id)
            .subscribe(res => {
              this.vokabeln = res;
            });
          });
      });
  }
}
