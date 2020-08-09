import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Bereich } from 'src/app/models/bereich';
import { Lektion } from 'src/app/models/lektion';
import { FortschrittService } from 'src/app/services/fortschritt.service';
import { LektionenService } from 'src/app/services/lektionen.service';

@Component({
  selector: 'app-trainieren-bereiche',
  templateUrl: './trainieren-bereiche.component.html',
  styleUrls: ['./trainieren-bereiche.component.less']
})
export class TrainierenBereicheComponent implements OnInit {
  lektionen: Lektion[] = [];
  modalRef?: BsModalRef;

  constructor(
    private fortschrittService: FortschrittService,
    private lektionenService: LektionenService,
    private toastr: ToastrService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.getLektionen();
  }

  getColor(lektion: Lektion): string {
    return this.lektionenService.getColorTrain(lektion);
  }

  getLektionen(): void {
    this.lektionenService
      .lektionen()
      .subscribe(res => {
        this.lektionen = res;
      });
  }

  reset(lektion: Lektion, bereich: Bereich) {
    this.fortschrittService
      .resetFortschrittLektionBereich(lektion.id, bereich.id)
      .subscribe(res => {
        if (res) {
          this.toastr.success(`Der Bereich '${bereich.name}' der Lektion '${lektion.name}' wurde erfolgreich zurückgesetzt.`)
          this.getLektionen();
        } else {
          this.toastr.error(`Fehler beim Zurücksetzen des Bereiches '${bereich.name}' der Lektion '${lektion.name}'.`)
        }
      });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(lektion: Lektion, bereich: Bereich): void {
    this.reset(lektion, bereich);
    this.modalRef!.hide();
  }

  decline(): void {
    this.modalRef!.hide();
  }
}
