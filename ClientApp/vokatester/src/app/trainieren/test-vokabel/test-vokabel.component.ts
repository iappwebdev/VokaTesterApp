import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { CheckResult, SimilarityResult } from 'src/app/models/check-result';
import { Lektion } from 'src/app/models/lektion';
import { Vokabel } from 'src/app/models/vokabel';
import { CheckResultService } from 'src/app/services/check-result.service';
import { TrainierenService } from 'src/app/services/trainieren.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-vokabel',
  templateUrl: './test-vokabel.component.html',
  styleUrls: ['./test-vokabel.component.less'],

})
export class TestVokabelComponent implements OnInit {
  @Input() lektion: Lektion | null = null;
  @Input() vokabel: Vokabel | null = null;
  @Output() onProceed = new EventEmitter<CheckResult>();
  @ViewChild('refAntwort') inpAntwort!: ElementRef;
  @ViewChild('refTest') btnFortsetzen!: MatButton;

  isProdMode = environment.production;
  hasAnswered: boolean = false;
  lastVokabelCorrect: boolean = false;
  numCorrectAnswersInRow = 0;

  vokabelForm = this.fb.group({
    'antwort': ['', [Validators.required]],
  });

  checkResult: CheckResult | null = null;

  constructor(
    private fb: FormBuilder,
    private sanitizer: DomSanitizer,
    private checkResultService: CheckResultService,
    private trainierenService: TrainierenService
  ) { }

  ngOnInit(): void {
  }

  get antwort(): AbstractControl {
    return this.vokabelForm.get('antwort') as AbstractControl;
  }

  get similarityResult(): SimilarityResult {
    return this.checkResult!.similarityResult;
  }

  checkAnswer(): void {
    if (!this.vokabel!.id || !this.antwort!.value) return;
    this.forceAnswer();
  }

  forceAnswer(): void {
    this.antwort.disable();
    if (!this.antwort.value) this.antwort.setValue(' ');
    const isPrevVokabel = this.vokabel!.isInserted
    this.trainierenService.checkAnswer(
      this.vokabel!.id,
      this.antwort.value,
      this.vokabel!.isInserted).subscribe(data => {
        this.hasAnswered = true;
        this.checkResult = data;
        this.lastVokabelCorrect = this.isCorrect();
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
      && this.checkResultService.isCorrect(this.checkResult!);
  }

  isArtikelFehlerOnly(): boolean {
    return this.hasAnswered
      && this.checkResultService.isArtikelFehlerOnly(this.checkResult!);
  }

  isSimilarOnly(): boolean {
    return this.hasAnswered
      && this.checkResultService.isSimilarOnly(this.checkResult!);
  }

  isSimilarAndArtikelFehler(): boolean {
    return this.hasAnswered
      && this.checkResultService.isSimilarAndArtikelFehler(this.checkResult!);
  }

  isWrong(): boolean {
    return this.hasAnswered
      && this.checkResultService.isWrong(this.checkResult!);
  }

  getHtmlStringTruthCorrect(): SafeHtml {
    let htmlStringArticle = TestVokabelComponent.getHtmlStringArticle(this.checkResult!.truthArticle);
    let htmlResult = htmlStringArticle + this.checkResult!.truthSan;

    return this.sanitizer.bypassSecurityTrustHtml(htmlResult);
  }

  getHtmlStringTruthSimilar(): SafeHtml {
    const spanStart = '<span style="text-decoration: underline; font-weight: bold;">'
    const spanEnd = '</span>'
    const posEditOps = this.checkResult!.similarityResult.editOperationsLeventhein!;
    let idx = -1;
    let htmlStringTruth = this.checkResult!.truthSan.split('').map(function (el) {
      idx++;
      if (posEditOps.some(x => x.key === idx)) {
        return spanStart + el + spanEnd;
      }
      return el;
    }).join('');

    let htmlStringArticle = TestVokabelComponent.getHtmlStringArticle(this.checkResult!.truthArticle);
    let htmlResult = htmlStringArticle + htmlStringTruth;

    return this.sanitizer.bypassSecurityTrustHtml(htmlResult);
  }

  private static getHtmlStringArticle(frz: string): string {
    if (!frz) return '';

    const spanStartMasc = '<span style="color: blue">'
    const spanStartFem = '<span style="color: red">'
    const spanEnd = '</span>'

    const artMasc = ['un', 'le'];

    artMasc.forEach((art) => {
      if (frz === art) {
        frz = spanStartMasc + art + spanEnd + ' ';
      }
    });

    const artFem = ['une', 'la'];

    artFem.forEach((art) => {
      if (frz === art) {
        frz = spanStartFem + art + spanEnd + ' ';
      }
    })

    return frz;
  }

  proceed(): void {
    let copyCheckResult = Object.assign({}, this.checkResult);
    this.onProceed.emit(copyCheckResult);
    this.reset();
    this.inpAntwort.nativeElement.focus();
  }

  private reset(): void {
    this.antwort?.reset();
    this.hasAnswered = false;
    this.checkResult = null;
    this.antwort.enable();
  }
}
