import { Component, OnInit } from '@angular/core';
import { AppTile } from '../../models/app-tile';

@Component({
  selector: 'app-main-trainieren',
  templateUrl: './main-trainieren.component.html',
  styleUrls: ['./main-trainieren.component.less']
})
export class MainTrainierenComponent implements OnInit {
  tiles: AppTile[] = [
    {
      id: 1,
      text: 'Vokabeln trainieren nach Lektion',
      descr: 'Hier kannst du die Vokabeln nach den Lektionen deines Buches trainieren.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/trainieren/lektionen',
      isLearning: false,
      isTraining: true
    },
    {
      id: 2,
      text: 'Vokabeln trainieren nach Wortnetzen',
      descr: 'Hier kannst du die Vokabeln nach Wortnetzen trainieren.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/trainieren/wortnetze',
      isLearning: false,
      isTraining: true
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
