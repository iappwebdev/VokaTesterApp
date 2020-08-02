import { Component, OnInit } from '@angular/core';
import { AppTile } from 'src/app/models/app-tile';

@Component({
  selector: 'app-main-lernen',
  templateUrl: './main-lernen.component.html',
  styleUrls: ['./main-lernen.component.less']
})
export class MainLernenComponent implements OnInit {
  tiles: AppTile[] = [
    {
      id: 1,
      text: 'Vokabeln lernen nach Lektion',
      descr: 'Hier kannst du die Vokabeln nach den Lektionen deines Buches lernen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/lernen/lektionen',
      isLearning: true,
      isTraining: false
    },
    {
      id: 2,
      text: 'Vokabeln lernen nach Wortnetzen',
      descr: 'Hier kannst du die Vokabeln nach Wortnetzen lernen.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/lernen/wortnetze',
      isLearning: true,
      isTraining: false
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
