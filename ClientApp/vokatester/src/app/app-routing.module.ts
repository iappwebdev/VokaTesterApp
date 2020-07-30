import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './identity/login/login.component';
import { RegisterComponent } from './identity/register/register.component';
import { LernenLektionComponent } from './lernen/lernen-lektion/lernen-lektion.component';
import { LernenLektionenComponent } from './lernen/lernen-lektionen/lernen-lektionen.component';
import { LernenWortnetzeComponent } from './lernen/lernen-wortnetze/lernen-wortnetze.component';
import { MainLernenComponent } from './lernen/main-lernen/main-lernen.component';
import { AuthGuardService } from './services/auth-guard.service';
import { MainTrainierenComponent } from './trainieren/main-trainieren/main-trainieren.component';
import { TrainierenLektionenComponent } from './trainieren/trainieren-lektionen/trainieren-lektionen.component';
import { TrainierenWortnetzeComponent } from './trainieren/trainieren-wortnetze/trainieren-wortnetze.component';
import { CreateVokabelComponent } from './vokabel/create-vokabel/create-vokabel.component';


const defaultPath = 'vokabeln';
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'create-vokabel', component: CreateVokabelComponent, canActivate: [AuthGuardService] },
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