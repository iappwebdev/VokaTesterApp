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
      text: 'Übersicht der Vokabel',
      descr: 'Hier kannst du die Vokabeln in einer Übersicht ansehen und durchsuchen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/uebersicht',
      isOverview: true
    },
    {
      id: 2,
      text: 'Übung der Vokabeln',
      descr: 'Hier kannst du deine gelernten Vokabeln üben.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/übung',
      isTraining: true
    },
    {
      id: 3,
      text: 'Testresultate',
      descr: 'Hier kannst du die Testresultate deine geübten Vokabeln ansehen und durchsuchen.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/test-results',
      isTestResults: true
    }
  ];

  lektionen: Lektion[] = [];

  constructor(
    private lektionenService: LektionenService
  ) { }

  ngOnInit(): void {
    this.lektionenService.lektionen()
      .subscribe(res => {
        this.lektionen = res;
      })
  }
}
