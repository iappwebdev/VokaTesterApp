import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Bereich } from 'src/app/models/bereich';
import { CheckResult } from 'src/app/models/check-result';
import { Lektion } from 'src/app/models/lektion';
import { Vokabel } from 'src/app/models/vokabel';
import { CheckResultService } from 'src/app/services/check-result.service';
import { FortschrittService } from 'src/app/services/fortschritt.service';
import { LektionenService } from 'src/app/services/lektionen.service';
import { VokabelService } from 'src/app/services/vokabel.service';

@Component({
  selector: 'app-trainieren-bereich',
  templateUrl: './trainieren-bereich.component.html',
  styleUrls: ['./trainieren-bereich.component.less']
})
export class TrainierenBereichComponent implements OnInit {
  private idx: number = -1;
  private vokabeln: Vokabel[] = [];

  lektion!: Lektion;
  bereich!: Bereich;

  constructor(
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private checkResultService: CheckResultService,
    private fortschrittService: FortschrittService,
    private lektionenService: LektionenService,
    private vokabelService: VokabelService
  ) { }

  ngOnInit(): void {
    this.route.paramMap
      .subscribe(params => {
        const lektionKey: string = params.get('lektionKey')!;
        const bereichKey: string = params.get('bereichKey')!;

        this.lektionenService
          .lektion(lektionKey)
          .subscribe(lektion => {
            this.lektion = lektion;
            this.bereich = lektion.bereiche.find(x => x.key == bereichKey)!;

            this.vokabelService
              .byLektionBereich(this.lektion.id, this.bereich.id)
              .subscribe(vokabeln => {
                this.vokabeln = vokabeln;

                this.fortschrittService
                  .getFortschrittLektionBereich(this.lektion.id, this.bereich.id)
                  .subscribe(fortschritt => {
                    let lastVokabeld = fortschritt.letzteVokabelCorrectId;

                    if (fortschritt?.letzteVokabelWrongId !== null
                      && fortschritt.letzteVokabelWrongId! < lastVokabeld) {
                      lastVokabeld = fortschritt.letzteVokabelWrongId!;
                    }

                    var index = this.vokabeln.findIndex(x => x.id == lastVokabeld);

                    // Ggf. Neustart der Lektion
                    if (index < 0
                      || index >= this.vokabeln.length) {
                      index = 0;
                    }

                    this.idx = index;
                  });
              });
          });
      });
  }

  get currentVokabel(): Vokabel | null {
    if (this.idx < 0 || !this.vokabeln?.length) return null;
    return this.vokabeln[this.idx];
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

  proceed(checkResult: CheckResult): void {
    const lastVokabelCorrect = this.checkResultService.isCorrect(checkResult);
    if (!lastVokabelCorrect) {
      let copyVokabel = Object.assign({}, this.currentVokabel);

      // Bei Accent Fehler ähnliche Vokabel ermitteln
      if (this.checkResultService.isSimilarOnly(checkResult)
        || this.checkResultService.isSimilarAndArtikelFehler(checkResult)) {
        const replaceOp = checkResult.similarityResult.replaceOps[0];

        this.vokabelService
          .previousBySimilarity(this.currentVokabel!.id, replaceOp.pattern, replaceOp.prev, replaceOp.next)
          .subscribe(res => {
            // Nächste ähnliche Vokabel einfügen
            if (res.length) {
              const takePos = Math.floor((Math.random() * res.length) + 0);
              const prevVokabel = res[takePos];
              prevVokabel.isInserted = true;
              prevVokabel.reasonInserted = copyVokabel!.frzSan;
              this.vokabeln.splice(this.idx + 1, 0, prevVokabel);
            }

            this.proceedToNextVokabel();
          });
      }
      else {
        this.proceedToNextVokabel();
      }

      copyVokabel.wiederholung = copyVokabel.wiederholung ? copyVokabel.wiederholung + 1 : 1;
      const insertPos = Math.floor((Math.random() * 5) + 2);
      this.vokabeln.splice(this.idx + insertPos, 0, copyVokabel);
    }
    else {
      this.proceedToNextVokabel();
    }
  }

  proceedToNextVokabel(): void {
    if (this.idx + 1 < this.vokabeln.length) {
      this.idx++;
    } else {
      this.fortschrittService.finishLektionBereich(this.lektion.id, this.bereich.id).subscribe(res => {
        this.toastr.success('Du hast den Bereich der Lektion erfolgreich abgeschlossen.', 'Bereich abgeschlossen!');
      })
      this.idx = 0;
    }
  }
}
