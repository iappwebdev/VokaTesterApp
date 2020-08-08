import { Component } from '@angular/core';
import { AppTile } from 'src/app/models/app-tile';

@Component({
  selector: 'app-main-uebersicht',
  templateUrl: './main-uebersicht.component.html',
  styleUrls: ['./main-uebersicht.component.less']
})
export class MainUebersichtComponent {
  tiles: AppTile[] = [
    {
      id: 1,
      text: 'Übersicht der Vokabeln nach Lektion',
      descr: 'Hier kannst du je Lektion die Vokabeln ansehen und durchsuchen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/uebersicht/lektionen',
      isOverview: true,
      isTraining: false
    },
    {
      id: 1,
      text: 'Übersicht der Vokabeln gesamt',
      descr: 'Hier kannst du alle Vokabeln ansehen und durchsuchen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/uebersicht/gesamt',
      isOverview: true,
      isTraining: false
    },
    // {
    //   id: 2,
    //   text: 'Übersicht der Vokabeln nach Wortnetzen',
    //   descr: 'Hier kannst du je Wortnetz die Vokabeln in einer Übersicht ansehen und durchsuchen.',
    //   photo: '../../assets/images/ki2.webp',
    //   link: '/vokabeln/uebersicht/wortnetze',
    //   isOverview: true,
    //   isTraining: false
    // }
  ];

  constructor() { }

}
