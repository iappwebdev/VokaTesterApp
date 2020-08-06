import { Component, OnInit } from '@angular/core';
import { AppTile } from 'src/app/models/app-tile';
import { Lektion } from 'src/app/models/lektion';
import { LektionenService } from 'src/app/services/lektionen.service';

@Component({
  selector: 'app-main',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {
  tiles: AppTile[] = [
    {
      id: 1,
      text: 'Vokabelübersicht',
      descr: 'Hier kannst du die Vokabeln in einer Übersicht ansehen und durchsuchen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/übersicht',
      isOverview: true,
      isTraining: false
    },
    {
      id: 2,
      text: 'Vokabeln üben',
      descr: 'Hier kannst du deine gelernten Vokabeln üben.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/übungen',
      isOverview: false,
      isTraining: true
    }
  ];

  lektionen: Lektion[] = [];

  constructor(
    private lektionenService: LektionenService
  ) { }

  ngOnInit(): void {
    this.lektionenService.lektionen().subscribe(res => {
      this.lektionen = res;
    })
  }
}
