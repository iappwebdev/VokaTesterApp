import { Component, OnInit } from '@angular/core';
import { AppTile } from 'src/app/models/app-tile';

@Component({
  selector: 'app-main-übersicht',
  templateUrl: './main-übersicht.component.html',
  styleUrls: ['./main-übersicht.component.less']
})
export class MainÜbersichtComponent implements OnInit {
  tiles: AppTile[] = [
    {
      id: 1,
      text: 'Vokabelübersicht nach Lektion',
      descr: 'Hier kannst du je Lektion die Vokabeln in einer Übersicht ansehen und durchsuchen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/übersicht/lektionen',
      isOverview: true,
      isTraining: false
    },
    // {
    //   id: 2,
    //   text: 'Vokabelübersicht nach Wortnetzen',
    //   descr: 'Hier kannst du je Wortnetz die Vokabeln in einer Übersicht ansehen und durchsuchen.',
    //   photo: '../../assets/images/ki2.webp',
    //   link: '/vokabeln/übersicht/wortnetze',
    //   isOverview: true,
    //   isTraining: false
    // }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
