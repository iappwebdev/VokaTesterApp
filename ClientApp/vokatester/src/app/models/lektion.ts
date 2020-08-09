import { Bereich } from 'src/app/models/bereich';

export interface Lektion {
  id: number;
  key: string;
  name: string;
  titel: string;
  subTitel: string;
  inhalt: string;
  position: number;
  total: number;
  firstVokabelId: number,
  lastVokabelId: number,
  isStarted: boolean;
  isCompleted: boolean;
  bereiche: Bereich[];
}