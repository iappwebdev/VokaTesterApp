export interface Vokabel {
  id: number;
  positionLektion: number;
  positionBereich: number;
  lektionId: number;
  lektionName: string;
  bereichId: number;
  bereichName: string;
  caseSensitive: boolean;
  frz: string;
  frzSan: string;
  phonetik: string;
  deu: string;
  deutSan: string;
  wiederholung: number;
  isInserted: boolean;
  reasonInserted: string;
}