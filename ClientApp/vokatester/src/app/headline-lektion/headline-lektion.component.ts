import { Component, Input, OnInit } from '@angular/core';
import { Lektion } from 'src/app/models/lektion';

@Component({
  selector: 'app-headline-lektion',
  templateUrl: './headline-lektion.component.html',
  styleUrls: ['./headline-lektion.component.less']
})
export class HeadlineLektionComponent implements OnInit {
  @Input() lektion: Lektion | null = null;

  constructor() { }

  ngOnInit(): void {
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
}
