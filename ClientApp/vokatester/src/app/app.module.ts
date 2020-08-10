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
import { LoadingScreenInterceptor } from 'src/app/services/infrastructure/loading-screen-interceptor.service';
import { TokenInterceptorService } from 'src/app/services/infrastructure/token-interceptor.service';
import { TestResultsService } from 'src/app/services/test-results.service';
import { TrainierenService } from 'src/app/services/trainieren.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeadlineLektionComponent } from './headline-lektion/headline-lektion.component';
import { HeadlineComponent } from './headline/headline.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './identity/login/login.component';
import { RegisterComponent } from './identity/register/register.component';
import { IpaAlphabetComponent } from './ipa-alphabet/ipa-alphabet.component';
import { LayoutComponent } from './layout/layout.component';
import { LoadingScreenComponent } from './loading-screen/loading-screen.component';
// import { UebersichtWortnetzeComponent } from './uebersicht/uebersicht-wortnetze/uebersicht-wortnetze.component';
import { MaterialModule } from './modules/material/material.module';
import { NavigationComponent } from './navigation/navigation.component';
import { CheckResultService } from './services/check-result.service';
import { FortschrittService } from './services/fortschritt.service';
import { AuthGuardService } from './services/infrastructure/auth-guard.service';
import { LektionenService } from './services/lektionen.service';
import { VokabelService } from './services/vokabel.service';
import { SonderzeichenLeisteComponent } from './sonderzeichen-leiste/sonderzeichen-leiste.component';
import { SonderzeichenComponent } from './sonderzeichen/sonderzeichen.component';
import { TableTestResultsComponent } from './test-results/table-test-results/table-test-results.component';
import { TestResultOverviewComponent } from './test-results/test-result-overview/test-result-overview.component';
import { MainTrainierenComponent } from './trainieren/main-trainieren/main-trainieren.component';
import { TestVokabelComponent } from './trainieren/test-vokabel/test-vokabel.component';
import { TrainierenBereichComponent } from './trainieren/trainieren-bereich/trainieren-bereich.component';
import { TrainierenBereicheComponent } from './trainieren/trainieren-bereiche/trainieren-bereiche.component';
import { TrainierenLektionComponent } from './trainieren/trainieren-lektion/trainieren-lektion.component';
import { TrainierenLektionenComponent } from './trainieren/trainieren-lektionen/trainieren-lektionen.component';
import { MainUebersichtComponent } from './uebersicht/main-uebersicht/main-uebersicht.component';
import { TableVokabelnComponent } from './uebersicht/table-vokabeln/table-vokabeln.component';
import { UebersichtGesamtComponent } from './uebersicht/uebersicht-gesamt/uebersicht-gesamt.component';
import { UebersichtLektionComponent } from './uebersicht/uebersicht-lektion/uebersicht-lektion.component';
import { UebersichtLektionenComponent } from './uebersicht/uebersicht-lektionen/uebersicht-lektionen.component';
// import { TrainierenWortnetzeComponent } from './trainieren/trainieren-wortnetze/trainieren-wortnetze.component';

@NgModule({
  declarations: [
    AppComponent,
    HeadlineComponent,
    HomeComponent,
    LayoutComponent,
    UebersichtLektionComponent,
    UebersichtLektionenComponent,
    // UebersichtWortnetzeComponent,
    LoginComponent,
    MainUebersichtComponent,
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
    TrainierenBereichComponent,
    TrainierenBereicheComponent,
    UebersichtGesamtComponent,
    TableVokabelnComponent,
    IpaAlphabetComponent,
    TestResultOverviewComponent,
    TableTestResultsComponent,
    LoadingScreenComponent,
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
    TestResultsService,
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
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingScreenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
