import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Lektion } from 'src/app/models/lektion';
import { FortschrittService } from 'src/app/services/fortschritt.service';
import { LektionenService } from 'src/app/services/lektionen.service';

@Component({
  selector: 'app-trainieren-lektionen',
  templateUrl: './trainieren-lektionen.component.html',
  styleUrls: ['./trainieren-lektionen.component.less']
})
export class TrainierenLektionenComponent implements OnInit {
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

  getLektionen(): void {
    this.lektionenService.lektionen().subscribe(res => {
      this.lektionen = res;
    });
  }

  reset(lektion: Lektion) {
    this.fortschrittService.resetFortschritt(lektion.id).subscribe(res => {
      if (res) {
        this.toastr.success(`Lektion ${lektion.name} wurde erfolgreich zurückgesetzt.`)
        this.getLektionen();
      } else {
        this.toastr.success(`Fehler beim Zurücksetzen der Lektion ${lektion.name}.`)
      }
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(lektion: Lektion): void {
    this.reset(lektion);
    this.modalRef!.hide();
  }
 
  decline(): void {
    this.modalRef!.hide();
  }
}
