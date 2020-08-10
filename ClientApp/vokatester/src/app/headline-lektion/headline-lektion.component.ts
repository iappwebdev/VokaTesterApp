import { Component, Input } from '@angular/core';
import { Bereich } from 'src/app/models/bereich';
import { Lektion } from 'src/app/models/lektion';

@Component({
  selector: 'app-headline-lektion',
  templateUrl: './headline-lektion.component.html',
  styleUrls: ['./headline-lektion.component.less']
})
export class HeadlineLektionComponent {
  @Input() lektion: Lektion | null = null;
  @Input() bereich?: Bereich | undefined;

  constructor() { }

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
    let title = this.lektion.name;
    if (this.lektion.titel && this.lektion.titel !== ' ') title += ` - ${this.lektion.titel}`;
    if (this.bereich) title = `${this.bereich.name} (${title})`;
    return title;
  }
}
