import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/home/home.component';
import { LoginComponent } from 'src/app/identity/login/login.component';
import { RegisterComponent } from 'src/app/identity/register/register.component';
import { AuthGuardService } from 'src/app/services/infrastructure/auth-guard.service';
import { MainTrainierenComponent } from 'src/app/trainieren/main-trainieren/main-trainieren.component';
import { TrainierenLektionComponent } from 'src/app/trainieren/trainieren-lektion/trainieren-lektion.component';
import { TrainierenLektionenComponent } from 'src/app/trainieren/trainieren-lektionen/trainieren-lektionen.component';
// import { TrainierenWortnetzeComponent } from 'src/app/trainieren/trainieren-wortnetze/trainieren-wortnetze.component';
import { MainÜbersichtComponent } from 'src/app/übersicht/main-übersicht/main-übersicht.component';
import { ÜbersichtLektionComponent } from 'src/app/übersicht/übersicht-lektion/übersicht-lektion.component';
import { ÜbersichtLektionenComponent } from 'src/app/übersicht/übersicht-lektionen/übersicht-lektionen.component';
// import { ÜbersichtWortnetzeComponent } from 'src/app/übersicht/übersicht-wortnetze/übersicht-wortnetze.component';

const defaultPath = 'vokabeln';
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'vokabeln', component: HomeComponent, canActivate: [AuthGuardService],
    data: { title: 'Home' }
  },
  {
    path: 'vokabeln/übersicht', component: MainÜbersichtComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabelübersicht', parent: 'vokabeln' }, 
  },
  {
    path: 'vokabeln/übersicht/lektionen', component: ÜbersichtLektionenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabelübersicht nach Lektionen', parent: 'vokabeln/übersicht' }, 
  },
  {
    path: 'vokabeln/übersicht/lektionen/:id', component: ÜbersichtLektionComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabelübersicht nach Lektion', parent: 'vokabeln/übersicht/lektionen' }, 
  },
  // {
  //   path: 'vokabeln/übersicht/wortnetze', component: ÜbersichtWortnetzeComponent, canActivate: [AuthGuardService],
  //   data: { title: 'Vokabelübersicht nach Wortnetzen', parent: 'vokabeln/übersicht' }, 
  // },
  {
    path: 'vokabeln/übungen', component: MainTrainierenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben', parent: 'vokabeln' }, 
  },
  {
    path: 'vokabeln/übungen/lektionen', component: TrainierenLektionenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben nach Lektionen', parent: 'vokabeln/übungen' }, 
  },
  {
    path: 'vokabeln/übungen/lektionen/:id', component: TrainierenLektionComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln üben nach Lektion', parent: 'vokabeln/übungen/lektionen' }, 
  },
  // {
  //   path: 'vokabeln/übungen/wortnetze', component: TrainierenWortnetzeComponent, canActivate: [AuthGuardService],
  //   data: { title: 'Vokabeln trainieren nach Wortnetzen', parent: 'vokabeln/übungen' }, 
  // },
  { path: '', redirectTo: defaultPath, pathMatch: 'prefix' },
  { path: '**', redirectTo: defaultPath }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }