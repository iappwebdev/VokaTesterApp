import { Component, OnInit } from '@angular/core';
import { IpaZeichen } from 'src/app/models/ipa-zeichen';

@Component({
  selector: 'app-ipa-alphabet',
  templateUrl: './ipa-alphabet.component.html',
  styleUrls: ['./ipa-alphabet.component.less']
})

export class IpaAlphabetComponent implements OnInit {

  vokale: IpaZeichen[] = [];

  constructor() { }

  ngOnInit(): void {
    this.vokale.push(new IpaZeichen('', 'madame', ''))
    this.vokale.push(new IpaZeichen('', 'téléphoner', ''))
    this.vokale.push(new IpaZeichen('', 'je', ''))
  }

}
