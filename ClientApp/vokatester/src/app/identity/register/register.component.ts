import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormValidationService } from 'src/app/services/form-validation.service';
import { AuthService } from 'src/app/services/infrastructure/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  registerForm = this.fb.group({
    'username': ['', [Validators.required]],
    'email': ['', [Validators.required]],
    'password': ['', [Validators.required]]
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private formValidation: FormValidationService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
  }

  hasErrorRequired = (controlName: string) => this.formValidation.hasErrorRequired(this.registerForm, controlName);

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      this.toastr.success('Registrierung erfolgreich, Sie können sich nun anmelden!')
      this.router.navigate(['login'])
    });
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
