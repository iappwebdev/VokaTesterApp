import { Component, OnInit } from '@angular/core';
import { AppTile } from '../models/app-tile';

@Component({
  selector: 'app-main',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {
  tiles: AppTile[] = [
    {
      id: 1,
      text: 'Vokabeln lernen',
      descr: 'Hier kannst du die Vokabeln deines Buches lernen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/lernen',
      isLearning: true,
      isTraining: false
    },
    {
      id: 2,
      text: 'Vokabeln trainieren',
      descr: 'Hier kannst du deine gelernten Vokabeln trainieren.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/trainieren',
      isLearning: false,
      isTraining: true
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
