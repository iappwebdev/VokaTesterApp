import { Component, Input } from '@angular/core';
import { AbstractControl, FormBuilder } from '@angular/forms';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { Colors } from 'src/app/const/colors';
import { TestResult } from 'src/app/models/test-result';

const ART_MASC = ['un', 'le'];
const ART_FEM = ['une', 'la'];

@Component({
  selector: 'app-table-test-results',
  templateUrl: './table-test-results.component.html',
  styleUrls: ['./table-test-results.component.less']
})
export class TableTestResultsComponent {
  @Input() testResults!: TestResult[];

  searchForm = this.fb.group({
    'filter': ['']
  });
  
  hideCorrect: boolean = false;
  hideAccent: boolean = false;
  hideArtikel: boolean = false;
  hideWrong: boolean = false;

  constructor(
    private fb: FormBuilder,
    private sanitizer: DomSanitizer
  ) { }

  get filter(): AbstractControl {
    return this.searchForm.get('filter') as AbstractControl;
  }

  get filterQuery(): string {
    if (!this.filter?.value) return '';
    return this.filter.value;
  }

  get testResultsPreFiltered() {
    const preFiltered = this.testResults.filter(tr => {
      if (this.hideCorrect && (tr.isCorrect && !tr.isArtikelFehler)) return false;
      if (this.hideAccent && (tr.isSimilar || tr.isSimilarAndArtikelFehler)) return false;
      if (this.hideArtikel && (tr.isArtikelFehler || tr.isSimilarAndArtikelFehler)) return false;
      if (this.hideWrong && tr.isWrong) return false;
      return true;
    })

    return preFiltered;
  }

  get testResultsFiltered() {
    if (!this.filterQuery) return this.testResultsPreFiltered;
    
    return this.testResultsPreFiltered.filter(testResult =>
      testResult.truth.toLowerCase().indexOf(this.filterQuery) >= 0
      || testResult.answer.toLowerCase().indexOf(this.filterQuery) >= 0
    );
  }

  getAnswer(testResult: TestResult): string {
    if (!testResult.answer) return '---';
    if (testResult.isCorrect && !testResult.isArtikelFehler) return '='
    return testResult.answer; 
  }

  getFormattedDate(dateString: string): string {
    var date = new Date(dateString);
    var day = this.str_pad(date.getDate());
    var month = this.str_pad(date.getMonth());
    var year = date.getFullYear();
    var hours = this.str_pad(date.getHours());
    var min = this.str_pad(date.getMinutes());
    var sec = this.str_pad(date.getSeconds());

    return `${day}.${month}.${year} ${hours}:${min}:${sec}`;
  }

  getHtmlStringFrz(frz: string): SafeHtml {
    const spanStartMasc = `<span style="color: ${Colors.MASC}">`
    const spanStartFem = `<span style="color: ${Colors.FEM}">`
    const spanEnd = '</span>'

    ART_MASC.forEach((art) => {
      const searchStr = art + ' ';
      if (frz.startsWith(searchStr)) {
        frz = frz.replace(searchStr, spanStartMasc + searchStr + spanEnd);
      }
    });

    ART_FEM.forEach((art) => {
      const searchStr = art + ' ';
      if (frz.startsWith(searchStr)) {
        frz = frz.replace(searchStr, spanStartFem + searchStr + spanEnd);
      }
    })

    return this.sanitizer.bypassSecurityTrustHtml(frz);
  }

  isTruthArticleMasc(frz: string): boolean {
    return ART_MASC.some((art) => frz.startsWith(art + ' '));
  } 

  isTruthArticleFem(frz: string): boolean {
    return ART_FEM.some((art) => frz.startsWith(art + ' '));
  } 

  toggleCorrect(): void {
    this.hideCorrect = !this.hideCorrect;
  }

  toggleAccent(): void {
    this.hideAccent = !this.hideAccent;
  }

  toggleArtikel(): void {
    this.hideArtikel = !this.hideArtikel;
  }

  toggleWrong(): void {
    this.hideWrong = !this.hideWrong;
  }

  private str_pad(n: number): string {
    return String('0' + n).slice(-2);
  }
}