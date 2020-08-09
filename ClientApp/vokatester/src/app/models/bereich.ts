export interface Bereich {
  id: number;
  key: string;
  abkuerzung: string;
  lektionName: string;
  name: string;
  position: number;
  total: number;
  firstVokabelId: number,
  lastVokabelId: number,
  isStarted: boolean;
  isCompleted: boolean;
}