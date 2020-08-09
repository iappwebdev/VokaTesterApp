import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/home/home.component';
import { LoginComponent } from 'src/app/identity/login/login.component';
import { AuthGuardService } from 'src/app/services/infrastructure/auth-guard.service';
import { MainTrainierenComponent } from 'src/app/trainieren/main-trainieren/main-trainieren.component';
import { TrainierenBereichComponent } from 'src/app/trainieren/trainieren-bereich/trainieren-bereich.component';
import { TrainierenBereicheComponent } from 'src/app/trainieren/trainieren-bereiche/trainieren-bereiche.component';
import { TrainierenLektionComponent } from 'src/app/trainieren/trainieren-lektion/trainieren-lektion.component';
import { TrainierenLektionenComponent } from 'src/app/trainieren/trainieren-lektionen/trainieren-lektionen.component';
// import { TrainierenWortnetzeComponent } from 'src/app/trainieren/trainieren-wortnetze/trainieren-wortnetze.component';
import { MainUebersichtComponent } from 'src/app/uebersicht/main-uebersicht/main-uebersicht.component';
import { UebersichtGesamtComponent } from 'src/app/uebersicht/uebersicht-gesamt/uebersicht-gesamt.component';
import { UebersichtLektionComponent } from 'src/app/uebersicht/uebersicht-lektion/uebersicht-lektion.component';
import { UebersichtLektionenComponent } from 'src/app/uebersicht/uebersicht-lektionen/uebersicht-lektionen.component';
import { TestResultOverviewComponent } from './test-results/test-result-overview/test-result-overview.component';
// import { UebersichtWortnetzeComponent } from 'src/app/uebersicht/uebersicht-wortnetze/uebersicht-wortnetze.component';

const defaultPath = 'vokabeln';
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  // { path: 'register', component: RegisterComponent },
  {
    path: 'vokabeln', component: HomeComponent, canActivate: [AuthGuardService],
    data: { title: 'Home' }
  },
  {
    path: 'vokabeln/liste', component: MainUebersichtComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabel-Liste', parent: 'vokabeln' }, 
  },
  {
    path: 'vokabeln/liste/lektionen', component: UebersichtLektionenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabel-Liste nach Lektionen', parent: 'vokabeln/liste' }, 
  },
  {
    path: 'vokabeln/liste/gesamt', component: UebersichtGesamtComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabel-Liste gesamt', parent: 'vokabeln/liste' }, 
  },
  {
    path: 'vokabeln/liste/lektionen/:lektionKey', component: UebersichtLektionComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabel-Liste nach Lektion', parent: 'vokabeln/liste/lektionen' }, 
  },
  // {
  //   path: 'vokabeln/liste/wortnetze', component: UebersichtWortnetzeComponent, canActivate: [AuthGuardService],
  //   data: { title: 'Vokabel-Liste nach Wortnetzen', parent: 'vokabeln/liste' }, 
  // },
  {
    path: 'vokabeln/übung', component: MainTrainierenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben', parent: 'vokabeln' }, 
  },
  {
    path: 'vokabeln/übung/lektionen', component: TrainierenLektionenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben nach Lektionen', parent: 'vokabeln/übung' }, 
  },
  {
    path: 'vokabeln/übung/lektionen/bereiche', component: TrainierenBereicheComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben nach Lektionsbereichen', parent: 'vokabeln/übung' }, 
  },
  {
    path: 'vokabeln/übung/lektionen/:lektionKey', component: TrainierenLektionComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben nach Lektion', parent: 'vokabeln/übung/lektionen' }, 
  },
  {
    path: 'vokabeln/übung/lektionen/:lektionKey/bereiche/:bereichKey', component: TrainierenBereichComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben nach Lektionsbereich', parent: 'vokabeln/übung/lektionen/bereiche' }, 
  },
  // {
  //   path: 'vokabeln/übung/wortnetze', component: TrainierenWortnetzeComponent, canActivate: [AuthGuardService],
  //   data: { title: 'Vokabeln üben nach Wortnetzen', parent: 'vokabeln/übung' }, 
  // },
  {
    path: 'vokabeln/testprotokoll', component: TestResultOverviewComponent, canActivate: [AuthGuardService],
    data: { title: 'Test-Protokoll', parent: 'vokabeln' }, 
  },
  { path: '', redirectTo: defaultPath, pathMatch: 'prefix' },
  { path: '**', redirectTo: defaultPath }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }