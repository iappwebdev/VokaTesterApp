import { Component } from '@angular/core';
import { AppTile } from 'src/app/models/app-tile';

@Component({
  selector: 'app-main-trainieren',
  templateUrl: './main-trainieren.component.html',
  styleUrls: ['./main-trainieren.component.less']
})
export class MainTrainierenComponent {
  tiles: AppTile[] = [
    {
      id: 1,
      text: 'Vokabeln trainieren nach Lektion',
      descr: 'Hier kannst du die Vokabeln nach den Lektionen deines Buches trainieren.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/übung/lektionen',
      isOverview: false,
      isTraining: true
    },
    {
      id: 1,
      text: 'Vokabeln trainieren nach Lektionsbereich',
      descr: 'Hier kannst du die Vokabeln nach den Bereichen in den Lektionen deines Buches trainieren.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/übung/lektionen/bereiche',
      isOverview: false,
      isTraining: true
    },
    // {
    //   id: 3,
    //   text: 'Vokabeln trainieren nach Wortnetzen',
    //   descr: 'Hier kannst du die Vokabeln nach Wortnetzen trainieren.',
    //   photo: '../../assets/images/ki2.webp',
    //   link: '/vokabeln/übung/wortnetze',
    //   isOverview: false,
    //   isTraining: true
    // }
  ];

  constructor() { }
}
