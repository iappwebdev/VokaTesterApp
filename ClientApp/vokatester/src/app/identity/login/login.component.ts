import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormValidationService } from 'src/app/services/form-validation.service';
import { AuthService } from 'src/app/services/infrastructure/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  loginForm = this.fb.group({
    'username': ['', [Validators.required]],
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
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['home-vokabeln'])
    }
  }

  hasErrorRequired = (controlName: string) => this.formValidation.hasErrorRequired(this.loginForm, controlName);

  login() {
    this.authService.login(this.loginForm.value).subscribe(data => {
      this.authService.saveToken(data.token);
      this.toastr.success('Willkommen!')
      this.router.navigate(['home-vokabeln'])
    })
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
}
