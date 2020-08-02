import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';

const sonderzeichen = ['à', 'â', 'é', 'è', 'ê', 'ë', 'î', 'û', 'ç'];

@Component({
  selector: 'app-sonderzeichen-leiste',
  templateUrl: './sonderzeichen-leiste.component.html',
  styleUrls: ['./sonderzeichen-leiste.component.less']
})
export class SonderzeichenLeisteComponent implements OnInit {
  @Input() input!: AbstractControl;
  @Input() inputRef!: ElementRef | unknown;

  cursorPos: number = 0;

  constructor() { }

  ngOnInit(): void {
    const inputElem: HTMLInputElement = this.inputRef as unknown as HTMLInputElement;
    inputElem.onblur = ($event) => this.saveCursorPos($event)
  }

  get sonderzeichen(): string[] {
    return sonderzeichen
  }

  saveCursorPos($event: any): void {
    let cursorPos = $event?.target?.selectionStart;
    this.cursorPos = !cursorPos ? this.input?.value?.length : cursorPos
  }
}
