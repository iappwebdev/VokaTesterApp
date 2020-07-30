import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { FormValidationService } from '../../services/form-validation.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private formValidation: FormValidationService,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.registerForm = this.fb.group({
      'username': ['', [Validators.required]],
      'email': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
  }

  hasErrorRequired = (controlName: string) => this.formValidation.hasErrorRequired(this.registerForm, controlName);

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      this.toastr.success('Registrierung erfolgreich, Sie können sich nun anmelden!')
      this.router.navigate(['login'])
    })
  }

  get username() {
    return this.registerForm.get('username');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }
}
