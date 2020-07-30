import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

const errors = {
  required: 'required'
}

@Injectable({
  providedIn: 'root'
})
export class FormValidationService {

  constructor() { }

  private hasError = (form: FormGroup, controlName: string, errorName: string) => {
    let control = form.get(controlName);
    return control?.touched && control?.hasError(errorName);
  }

  hasErrorRequired = (form: FormGroup, controlName: string) => {
    let control = form.get(controlName);
    return this.hasError(form, controlName, errors.required);
  }
}
