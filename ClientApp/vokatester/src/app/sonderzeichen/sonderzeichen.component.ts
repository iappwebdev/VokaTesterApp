import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-sonderzeichen',
  templateUrl: './sonderzeichen.component.html',
  styleUrls: ['./sonderzeichen.component.less']
})
export class SonderzeichenComponent implements OnInit {
  @Input() input!: AbstractControl;
  @Input() inputRef!: ElementRef | unknown;
  @Input() zeichen!: string;

  private inputElem!: HTMLInputElement;

  constructor() { }

  ngOnInit(): void {
    this.inputElem = this.inputRef as unknown as HTMLInputElement;
  }

  insertZeichen(): void {
    if (this.disabled()) return;
    let newValue: string = (!this.input.value) ? '' : this.input.value.toString()
    let startPos: number = !(this.inputElem.selectionStart) ? 0 : parseInt(this.inputElem.selectionStart?.toString());
    let endPos: number = !(this.inputElem.selectionEnd) ? 0 : parseInt(this.inputElem.selectionEnd?.toString());
    newValue = newValue.slice(0, startPos) + this.zeichen + newValue.slice(endPos);
    
    this.input.setValue(newValue);
    this.inputElem.focus();

    this.inputElem.selectionStart = startPos + 1;
    this.inputElem.selectionEnd = this.inputElem.selectionStart;
  }

  disabled(): boolean {
    return this.inputElem.disabled;
  }
}
