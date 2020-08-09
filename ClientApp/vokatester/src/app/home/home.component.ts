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
      text: 'Vokabel-Liste',
      descr: 'Hier kannst du die Vokabel-Listen ansehen und durchsuchen.',
      photo: '../../assets/images/learn.jpeg',
      link: '/vokabeln/liste',
      isOverview: true
    },
    {
      id: 2,
      text: 'Vokabeln-Übung',
      descr: 'Hier kannst du deine gelernten Vokabeln üben.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/übung',
      isTraining: true
    },
    {
      id: 3,
      text: 'Test-Protokoll',
      descr: 'Hier kannst du das Testprotokoll deiner geübten Vokabeln ansehen und durchsuchen.',
      photo: '../../assets/images/ki2.webp',
      link: '/vokabeln/testprotokoll',
      isTestProtokoll: true
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
