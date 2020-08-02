import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/home/home.component';
import { LoginComponent } from 'src/app/identity/login/login.component';
import { RegisterComponent } from 'src/app/identity/register/register.component';
import { LernenLektionComponent } from 'src/app/lernen/lernen-lektion/lernen-lektion.component';
import { LernenLektionenComponent } from 'src/app/lernen/lernen-lektionen/lernen-lektionen.component';
import { LernenWortnetzeComponent } from 'src/app/lernen/lernen-wortnetze/lernen-wortnetze.component';
import { MainLernenComponent } from 'src/app/lernen/main-lernen/main-lernen.component';
import { AuthGuardService } from 'src/app/services/infrastructure/auth-guard.service';
import { MainTrainierenComponent } from 'src/app/trainieren/main-trainieren/main-trainieren.component';
import { TrainierenLektionComponent } from 'src/app/trainieren/trainieren-lektion/trainieren-lektion.component';
import { TrainierenLektionenComponent } from 'src/app/trainieren/trainieren-lektionen/trainieren-lektionen.component';
import { TrainierenWortnetzeComponent } from 'src/app/trainieren/trainieren-wortnetze/trainieren-wortnetze.component';

const defaultPath = 'vokabeln';
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'vokabeln', component: HomeComponent, canActivate: [AuthGuardService],
    data: { title: 'Home' }
  },
  {
    path: 'vokabeln/lernen', component: MainLernenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln lernen', parent: 'vokabeln' }, 
  },
  {
    path: 'vokabeln/lernen/lektionen', component: LernenLektionenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln lernen nach Lektionen', parent: 'vokabeln/lernen' }, 
  },
  {
    path: 'vokabeln/lernen/lektionen/:id', component: LernenLektionComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln lernen nach Lektion', parent: 'vokabeln/lernen/lektionen' }, 
  },
  {
    path: 'vokabeln/lernen/wortnetze', component: LernenWortnetzeComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln lernen nach Wortnetzen', parent: 'vokabeln/lernen' }, 
  },
  {
    path: 'vokabeln/trainieren', component: MainTrainierenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln trainieren', parent: 'vokabeln' }, 
  },
  {
    path: 'vokabeln/trainieren/lektionen', component: TrainierenLektionenComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln trainieren nach Lektionen', parent: 'vokabeln/trainieren' }, 
  },
  {
    path: 'vokabeln/trainieren/lektionen/:id', component: TrainierenLektionComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln trainieren nach Lektion', parent: 'vokabeln/trainieren/lektionen' }, 
  },
  {
    path: 'vokabeln/trainieren/wortnetze', component: TrainierenWortnetzeComponent, canActivate: [AuthGuardService],
    data: { title: 'Vokabeln trainieren nach Wortnetzen', parent: 'vokabeln/trainieren' }, 
  },
  { path: '', redirectTo: defaultPath, pathMatch: 'prefix' },
  { path: '**', redirectTo: defaultPath }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }