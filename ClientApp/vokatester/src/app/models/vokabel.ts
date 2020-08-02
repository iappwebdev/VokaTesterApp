export interface Vokabel {
  id: number,
  lektionId: number,
  lektionName: string,
  bereichId: number,
  bereichName: string,
  caseSensitive: boolean,
  frz: string,
  frzSan: string,
  phonetik: string,
  deu: string,
  deutSan: string
}