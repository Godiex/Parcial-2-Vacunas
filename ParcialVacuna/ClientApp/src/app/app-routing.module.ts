import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { BusquedaPersonaComponent } from './Parcial2/Componentes/busqueda-persona/busqueda-persona.component';

const routes: Routes = [
  { path: '', component: InicioComponent },
  { path: 'busqueda-persona', component: BusquedaPersonaComponent }
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes)
],
exports: [RouterModule]
})
export class AppRoutingModule { }
