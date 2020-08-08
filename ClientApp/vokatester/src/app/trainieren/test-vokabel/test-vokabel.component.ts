import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { Colors } from 'src/app/const/colors';
import { Bereich } from 'src/app/models/bereich';
import { CheckResult, SimilarityResult } from 'src/app/models/check-result';
import { Lektion } from 'src/app/models/lektion';
import { Vokabel } from 'src/app/models/vokabel';
import { CheckResultService } from 'src/app/services/check-result.service';
import { TrainierenService } from 'src/app/services/trainieren.service';
import { environment } from 'src/environments/environment';

const SPAN_MASC = `<span style="color: ${Colors.MASC};">`
const SPAN_FEM = `<span style="color: ${Colors.FEM};">`

const SPAN_TABLE = '<span style="display: table-cell; text-align: center; vertical-align: middle;">';
const SPAN_ROW_1 = '<span style="display: table-row;">'
const SPAN_ROW_2 = '<span style="display: table-row; line-height: 0">';
const SPAN_CELL_ROW_1 = '<span style="display: table-cell; padding-bottom: 2px;">'
const SPAN_ACCENT = '<span style="font-weight: bold;">'
const SPAN_BLANK = '<span style="padding-right: 5px;">'
const SPAN_CELL_ROW_2 = '<span style="display: table-cell;">'
const SPAN_CELL_BORDER_TOP = '<span style="display: table-cell; border-top: 2px solid black">'
const SPAN_END = '</span>'

@Component({
  selector: 'app-test-vokabel',
  templateUrl: './test-vokabel.component.html',
  styleUrls: ['./test-vokabel.component.less'],

})
export class TestVokabelComponent {
  @Input() lektion: Lektion | null = null;
  @Input() bereich: Bereich | null = null;
  @Input() vokabel: Vokabel | null = null;
  @Output() onProceed = new EventEmitter<CheckResult>();
  @ViewChild('refAntwort') inpAntwort!: ElementRef;
  @ViewChild('refFortsetzen') btnFortsetzen!: MatButton;

  isProdMode = environment.production;
  hasAnswered: boolean = false;
  lastVokabelCorrect: boolean = false;
  numCorrectAnswersInRow = 0;
  numInserted = 0;

  vokabelForm = this.fb.group({
    'antwort': ['', [Validators.required]],
  });

  checkResult: CheckResult | null = null;

  readonly TRESHOLDS = [3, 6, 10];

  constructor(
    private fb: FormBuilder,
    private sanitizer: DomSanitizer,
    private checkResultService: CheckResultService,
    private trainierenService: TrainierenService
  ) { }

  get antwort(): AbstractControl {
    return this.vokabelForm.get('antwort') as AbstractControl;
  }

  get isBereich(): boolean {
    return this.bereich !== null;
  }

  get similarityResult(): SimilarityResult {
    return this.checkResult!.similarityResult;
  }

  isEmptyOrWhiteSpace(pattern: string): boolean {
    return pattern === null || pattern.match(/^ *$/) !== null;
  }

  checkAnswer(): void {
    if (!this.vokabel!.id || !this.antwort!.value) return;
    this.forceAnswer();
  }

  forceAnswer(): void {
    this.antwort.disable();
    if (!this.antwort.value) this.antwort.setValue('');

    this.trainierenService.checkAnswer(
      this.vokabel!.id,
      this.antwort.value,
      this.vokabel!.isInserted,
      this.isBereich
    )
      .subscribe(data => {
        this.hasAnswered = true;
        this.checkResult = data;
        this.lastVokabelCorrect = this.isCorrect();
        this.numCorrectAnswersInRow = this.isCorrect() ? this.numCorrectAnswersInRow + 1 : 0
        this.focusBtnFortsetzen();
      }, err => {
        this.hasAnswered = false;
        this.antwort.enable();
      });
  }

  private focusBtnFortsetzen(): void {
    setTimeout(() => {
      this.btnFortsetzen.focus();
    });
  }

  getPosition() {
    if (this.isBereich) return `${this.vokabel!.positionBereich}/${this.bereich!.total}`;
    return `${this.vokabel!.positionLektion}/${this.lektion!.total}`;
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

  getHtmlStringTruth(): SafeHtml {
    const posEditOps =
      this.isSimilarOnly() || this.isSimilarAndArtikelFehler()
        ? this.checkResult!.similarityResult?.editOperationsLeventhein
        : [];

    let htmlStringArticle = this.getHtmlStringArticle();

    let resultHtml = SPAN_TABLE // OPEN TABLE;

    resultHtml += SPAN_ROW_1 // OPEN ROW 1;
    resultHtml += SPAN_CELL_ROW_1 // OPEN ARTICLE CELL 1;
    resultHtml += htmlStringArticle // ARTICLE
    resultHtml += SPAN_END // CLOSE ARTICLE CELL 1;

    if (!this.isEmptyOrWhiteSpace(htmlStringArticle)) {
      resultHtml += SPAN_CELL_ROW_1 + SPAN_BLANK + SPAN_END + SPAN_END;
    }

    let idx = -1;
    resultHtml += this.checkResult!.truthSan.split('').map((el) => {
      idx++
      let res = SPAN_CELL_ROW_1; // OPEN CELL idx
      if (posEditOps.some(x => x.key === idx)) {
        res += SPAN_ACCENT + el + SPAN_END;
      } else if (this.isEmptyOrWhiteSpace(el)) {
        res += SPAN_BLANK + SPAN_END;
      } else {
        res += el
      }
      res += SPAN_END; // CLOSE CELL idx
      return res;
    }).join('');

    resultHtml += SPAN_END // CLOSE ROW 1;

    resultHtml += SPAN_ROW_2 // OPEN ROW 2;
    resultHtml += // OPEN ARTICLE CELL 2;
      this.isArtikelFehlerOnly() || this.isSimilarAndArtikelFehler()
        ? SPAN_CELL_BORDER_TOP
        : SPAN_CELL_ROW_2
    resultHtml += SPAN_END // CLOSE ARTICLE CELL 2;

    if (!this.isEmptyOrWhiteSpace(htmlStringArticle)) {
      resultHtml += SPAN_CELL_ROW_2 + SPAN_END;
    }

    idx = -1;
    resultHtml += this.checkResult!.truthSan.split('').map(function (el) {
      idx++
      if (posEditOps.some(x => x.key === idx)) {
        return SPAN_CELL_BORDER_TOP + SPAN_END; // OPEN & CLOSE BORDER TOP CELL idx
      }
      return SPAN_CELL_ROW_2 + SPAN_END; // OPEN & CLOSE TOP CELL idx
    }).join('');

    resultHtml += SPAN_END // CLOSE ROW 2;
    resultHtml += SPAN_END // CLOSE TABLE;

    return this.sanitizer.bypassSecurityTrustHtml(resultHtml);
  }

  private getHtmlStringArticle(): string {
    if (this.checkResult?.isTruthArticleFem) return SPAN_FEM + this.checkResult?.truthArticle + SPAN_END;
    if (this.checkResult?.isTruthArticleMasc) return SPAN_MASC + this.checkResult?.truthArticle + SPAN_END;
    return '';
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
