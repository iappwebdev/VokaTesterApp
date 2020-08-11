import { Component, Input } from '@angular/core';
import { AbstractControl, FormBuilder } from '@angular/forms';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { Colors } from 'src/app/const/colors';
import { Vokabel } from 'src/app/models/vokabel';

@Component({
  selector: 'app-table-vokabeln',
  templateUrl: './table-vokabeln.component.html',
  styleUrls: ['./table-vokabeln.component.less']
})
export class TableVokabelnComponent {
  @Input() vokabeln!: Vokabel[];

  searchForm = this.fb.group({
    'filter': ['']
  });

  constructor(
    private fb: FormBuilder,
    private sanitizer: DomSanitizer
  ) { }

  get filter(): AbstractControl {
    return this.searchForm.get('filter') as AbstractControl;
  }

  get filterQuery(): string {
    if (!this.filter?.value) return '';
    return this.filter.value.toLowerCase();
  }

  get vokabelnFiltered() {
    if (!this.filterQuery) return this.vokabeln;

    return this.vokabeln.filter(vokabel =>
      vokabel.frz.toLowerCase().indexOf(this.filterQuery.toLowerCase()) >= 0
      || vokabel.deu.toLowerCase().indexOf(this.filterQuery) >= 0
      || vokabel.phonetik.toLowerCase().indexOf(this.filterQuery) >= 0
    );
  }

  displayLektion(): boolean {
    var lektionen = this.vokabeln.map(function(item) {
      return item.lektionId;
    }, {});
    var set = new Set(lektionen);
    return set.size > 1;
  }

  getHtmlStringFrz(frz: string): SafeHtml {
    const spanStartMasc = `<span style="color: ${Colors.MASC}">`
    const spanStartFem = `<span style="color: ${Colors.FEM}">`
    const spanEnd = '</span>'

    const artMasc = ['un', 'le'];

    artMasc.forEach((art) => {
      const searchStr = art + ' ';
      if (frz.startsWith(searchStr)) {
        frz = frz.replace(searchStr, spanStartMasc + searchStr + spanEnd);
      }
    });

    const artFem = ['une', 'la'];

    artFem.forEach((art) => {
      const searchStr = art + ' ';
      if (frz.startsWith(searchStr)) {
        frz = frz.replace(searchStr, spanStartFem + searchStr + spanEnd);
      }
    })

    return this.sanitizer.bypassSecurityTrustHtml(frz);
  }
}
