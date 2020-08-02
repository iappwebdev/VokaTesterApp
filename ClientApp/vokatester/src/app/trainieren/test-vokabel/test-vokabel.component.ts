import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { CheckResult } from 'src/app/models/check-result';
import { Lektion } from 'src/app/models/lektion';
import { Vokabel } from 'src/app/models/vokabel';
import { TrainierenService } from 'src/app/services/trainieren.service';

@Component({
  selector: 'app-test-vokabel',
  templateUrl: './test-vokabel.component.html',
  styleUrls: ['./test-vokabel.component.less'],

})
export class TestVokabelComponent implements OnInit {
  @Input() lektion: Lektion | null = null;
  @Input() vokabel: Vokabel | null = null;
  @Output() onProceed = new EventEmitter();
  @ViewChild('refAntwort') inpAntwort!: ElementRef;
  @ViewChild('refTest') btnFortsetzen!: MatButton;

  hasAnswered: boolean = false;
  numCorrectAnswersInRow = 0;

  vokabelForm = this.fb.group({
    'antwort': ['', [Validators.required]],
  });

  checkResult: CheckResult | null = null;

  constructor(
    private fb: FormBuilder,
    private trainierenService: TrainierenService
  ) { }

  ngOnInit(): void {
  }

  get antwort(): AbstractControl {
    return this.vokabelForm.get('antwort') as AbstractControl;
  }

  checkAnswer(): void {
    if (!this.vokabel!.id || !this.antwort!.value) return;
    this.forceAnswer();
  }

  forceAnswer(): void {
    this.antwort.disable();
    if (!this.antwort.value) this.antwort.setValue(' ');
    this.trainierenService.checkAnswer(this.vokabel!.id, this.antwort.value).subscribe(data => {
      this.hasAnswered = true;
      this.checkResult = data;
      this.numCorrectAnswersInRow = this.isCorrect() ? this.numCorrectAnswersInRow + 1 : 0
      this.focusBtnFortsetzen();
    });
  }

  private focusBtnFortsetzen(): void {
    setTimeout(() => {
      this.btnFortsetzen.focus();
    });
  }

  isCorrect(): boolean {
    return this.hasAnswered
      && this.checkResult !== null
      && this.checkResult.isCorrect;
  }


  isSimilar(): boolean {
    return this.hasAnswered
      && this.checkResult !== null
      && !this.checkResult.isCorrect
      && this.checkResult.isSimilar;
  }

  isWrong(): boolean {
    return this.hasAnswered
      && this.checkResult !== null
      && !this.checkResult.isCorrect
      && !this.checkResult.isSimilar;
  }

  log(data: any): void {
    console.log(data);
  }

  proceed(): void {
    this.reset();
    this.inpAntwort.nativeElement.focus();
    this.onProceed.emit();
  }

  private reset(): void {
    this.antwort?.reset();
    this.hasAnswered = false;
    this.checkResult = null;
    this.antwort.enable();
  }
}
