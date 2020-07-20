import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateVokabelComponent } from './create-vokabel/create-vokabel.component';
import { HomeVokabelnComponent } from './home-vokabeln/home-vokabeln.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';

const defaultPath = 'create-vokabel';
const defaultComponent = CreateVokabelComponent;
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'home-vokabeln', component: HomeVokabelnComponent, canActivate: [AuthGuardService] },
  { path: 'create-vokabel', component: CreateVokabelComponent, canActivate: [AuthGuardService] },
  { path: '', redirectTo: defaultPath, pathMatch: 'prefix' },
  { path: '**', redirectTo: defaultPath }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
