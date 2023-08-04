import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';

import { EventosComponent } from './components/eventos/eventos.component';
import { EventoListComponent } from './components/eventos/evento-list/evento-list.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';

import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { ProfileComponent } from './components/user/profile/profile.component';

const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      {path: 'login', component: LoginComponent},
      {path: 'registration', component: RegistrationComponent},
    ]
  },
  {path: 'contatos', component: ContatosComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'eventos', redirectTo: 'eventos/lista'},
  {
    path: 'eventos', component: EventosComponent,
    children: [
      {path: 'detalhe/:id', component: EventoDetalheComponent},
      {path: 'detalhe', component: EventoDetalheComponent},
      {path: 'lista', component: EventoListComponent},
    ]
  },
  {path: 'palestrantes', component: PalestrantesComponent},
  {path: 'user/profile', component: ProfileComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
