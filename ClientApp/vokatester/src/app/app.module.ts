import { LayoutModule } from '@angular/cdk/layout';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './identity/login/login.component';
import { RegisterComponent } from './identity/register/register.component';
import { LayoutComponent } from './layout/layout.component';
import { LernenLektionenComponent } from './lernen/lernen-lektionen/lernen-lektionen.component';
import { LernenWortnetzeComponent } from './lernen/lernen-wortnetze/lernen-wortnetze.component';
import { MainLernenComponent } from './lernen/main-lernen/main-lernen.component';
import { MaterialModule } from './modules/material/material.module';
import { NavigationComponent } from './navigation/navigation.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AuthService } from './services/auth.service';
import { ErrorInterceptorService } from './services/error-interceptor.service';
import { LernenService } from './services/lernen.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { VokabelService } from './services/vokabel.service';
import { MainTrainierenComponent } from './trainieren/main-trainieren/main-trainieren.component';
import { TrainierenLektionenComponent } from './trainieren/trainieren-lektionen/trainieren-lektionen.component';
import { TrainierenWortnetzeComponent } from './trainieren/trainieren-wortnetze/trainieren-wortnetze.component';
import { CreateVokabelComponent } from './vokabel/create-vokabel/create-vokabel.component';
import { DetailsVokabelComponent } from './vokabel/details-vokabel/details-vokabel.component';
import { LernenLektionComponent } from './lernen/lernen-lektion/lernen-lektion.component';
import { HeadlineComponent } from './headline/headline.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CreateVokabelComponent,
    DetailsVokabelComponent,
    NavigationComponent,
    LayoutComponent,
    HomeComponent,
    MainLernenComponent,
    MainTrainierenComponent,
    LernenLektionenComponent,
    LernenWortnetzeComponent,
    TrainierenLektionenComponent,
    TrainierenWortnetzeComponent,
    LernenLektionComponent,
    HeadlineComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
      // preventDuplicates: true,
      closeButton: true,
      progressBar: true,
      tapToDismiss: true,
      newestOnTop: true
    }),
    MaterialModule,
    LayoutModule,
  ],
  providers: [
    AuthService,
    AuthGuardService,
    LernenService,
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
