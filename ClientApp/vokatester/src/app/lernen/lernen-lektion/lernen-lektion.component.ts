import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Lektion } from 'src/app/models/lektion';
import { Vokabel } from 'src/app/models/vokabel';
import { LektionenService } from 'src/app/services/lektionen.service';
import { VokabelService } from 'src/app/services/vokabel.service';

@Component({
  selector: 'app-lernen-lektion',
  templateUrl: './lernen-lektion.component.html',
  styleUrls: ['./lernen-lektion.component.less']
})
export class LernenLektionComponent implements OnInit {
  private vokabeln: Vokabel[] = [];

  lektion!: Lektion;
  searchForm = this.fb.group({
    'filter': ['']
  });

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
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
        this.vokabeln = res;
      });
    });

  }

  get filter(): AbstractControl {
    return this.searchForm.get('filter') as AbstractControl;
  }

  get filterQuery(): string {
    if (!this.filter?.value) return '';
    return this.filter.value;
  }

  get vokabelnFiltered() {
    if (!this.filterQuery) return this.vokabeln;

    return this.vokabeln.filter(vokabel =>
      vokabel.frz.toLowerCase().indexOf(this.filterQuery) >= 0
      || vokabel.deu.toLowerCase().indexOf(this.filterQuery) >= 0
    );
  }
}
