import { LayoutModule } from '@angular/cdk/layout';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { AuthService } from 'src/app/services/infrastructure/auth.service';
import { ErrorInterceptorService } from 'src/app/services/infrastructure/error-interceptor.service';
import { TokenInterceptorService } from 'src/app/services/infrastructure/token-interceptor.service';
import { TrainierenService } from 'src/app/services/trainieren.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeadlineLektionComponent } from './headline-lektion/headline-lektion.component';
import { HeadlineComponent } from './headline/headline.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './identity/login/login.component';
import { RegisterComponent } from './identity/register/register.component';
import { LayoutComponent } from './layout/layout.component';
// import { ÜbersichtWortnetzeComponent } from './übersicht/übersicht-wortnetze/übersicht-wortnetze.component';
import { MaterialModule } from './modules/material/material.module';
import { NavigationComponent } from './navigation/navigation.component';
import { CheckResultService } from './services/check-result.service';
import { FortschrittService } from './services/fortschritt.service';
import { AuthGuardService } from './services/infrastructure/auth-guard.service';
import { LektionenService } from './services/lektionen.service';
import { VokabelService } from './services/vokabel.service';
import { SonderzeichenLeisteComponent } from './sonderzeichen-leiste/sonderzeichen-leiste.component';
import { SonderzeichenComponent } from './sonderzeichen/sonderzeichen.component';
import { MainTrainierenComponent } from './trainieren/main-trainieren/main-trainieren.component';
import { TestVokabelComponent } from './trainieren/test-vokabel/test-vokabel.component';
import { TrainierenLektionComponent } from './trainieren/trainieren-lektion/trainieren-lektion.component';
import { TrainierenLektionenComponent } from './trainieren/trainieren-lektionen/trainieren-lektionen.component';
import { MainÜbersichtComponent } from './übersicht/main-übersicht/main-übersicht.component';
import { ÜbersichtLektionComponent } from './übersicht/übersicht-lektion/übersicht-lektion.component';
import { ÜbersichtLektionenComponent } from './übersicht/übersicht-lektionen/übersicht-lektionen.component';
// import { TrainierenWortnetzeComponent } from './trainieren/trainieren-wortnetze/trainieren-wortnetze.component';

@NgModule({
  declarations: [
    AppComponent,
    HeadlineComponent,
    HomeComponent,
    LayoutComponent,
    ÜbersichtLektionComponent,
    ÜbersichtLektionenComponent,
    // ÜbersichtWortnetzeComponent,
    LoginComponent,
    MainÜbersichtComponent,
    MainTrainierenComponent,
    NavigationComponent,
    RegisterComponent,
    TrainierenLektionComponent,
    TrainierenLektionenComponent,
    // TrainierenWortnetzeComponent,
    TestVokabelComponent,
    SonderzeichenComponent,
    SonderzeichenLeisteComponent,
    HeadlineLektionComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    FlexLayoutModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-top-center',
      preventDuplicates: true,
      closeButton: true,
      progressBar: true,
      tapToDismiss: true,
      newestOnTop: true,
      timeOut: 15000
    }),
    MaterialModule,
    LayoutModule,
  ],
  providers: [
    AuthService,
    AuthGuardService,
    CheckResultService,
    FortschrittService,
    LektionenService,
    TrainierenService,
    VokabelService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
