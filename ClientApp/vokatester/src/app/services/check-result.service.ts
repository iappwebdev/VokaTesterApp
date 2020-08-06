import { Injectable } from '@angular/core';
import { CheckResult } from 'src/app/models/check-result';

@Injectable({
  providedIn: 'root'
})
export class CheckResultService {

  constructor() { }

  isCorrect(checkResult: CheckResult): boolean {
    return checkResult !== null
      && checkResult.isCorrect
      && !checkResult.isArtikelFehler;
  }

  isArtikelFehlerOnly(checkResult: CheckResult): boolean {
    return checkResult !== null
      && checkResult.isCorrect
      && checkResult.isArtikelFehler
      && !checkResult.isSimilar;
  }

  isSimilarOnly(checkResult: CheckResult): boolean {
    return checkResult !== null
      && !checkResult.isCorrect
      && !checkResult.isArtikelFehler
      && checkResult.isSimilar;
  }

  isSimilarAndArtikelFehler(checkResult: CheckResult): boolean {
    return checkResult !== null
      && !checkResult.isCorrect
      && checkResult.isArtikelFehler
      && checkResult.isSimilar;
  }

  isWrong(checkResult: CheckResult): boolean {
    return checkResult !== null
      && !checkResult.isCorrect
      && !checkResult.isSimilar;
  }
}
