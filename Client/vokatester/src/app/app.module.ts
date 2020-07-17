import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service'
import { AuthGuardService } from './services/auth-guard.service'
import { VokabelService } from './services/vokabel.service'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CreateVokabelComponent } from './create-vokabel/create-vokabel.component'
import { TokenInterceptorService } from './services/token-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CreateVokabelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
      AuthService,
       AuthGuardService,
       VokabelService,
       {
           provide: HTTP_INTERCEPTORS,
           useClass: TokenInterceptorService,
           multi: true
       }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
