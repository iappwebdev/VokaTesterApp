import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { VokabelService } from '../services/vokabel.service';

@Component({
  selector: 'app-create-vokabel',
  templateUrl: './create-vokabel.component.html',
  styleUrls: ['./create-vokabel.component.less']
})
export class CreateVokabelComponent implements OnInit {
  vokabelForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private vokabelService: VokabelService,
    private toastr: ToastrService
  ) {
    this.vokabelForm = this.fb.group({
      'frz': ['', [Validators.required]],
      'deu': ['', [Validators.required]],
      'phonetik': ['', [Validators.required]],
      'imageUrl': ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
  }

  get frz() {
    return this.vokabelForm.get('frz');
  }

  get deu() {
    return this.vokabelForm.get('deu');
  }

  get phonetik() {
    return this.vokabelForm.get('phonetik');
  }

  get imageUrl() {
    return this.vokabelForm.get('imageUrl');
  }

  create() {
    this.vokabelService.create(this.vokabelForm.value).subscribe(res => {
      this.toastr.success('Vokabel angelegt.');
    });
  }
}
