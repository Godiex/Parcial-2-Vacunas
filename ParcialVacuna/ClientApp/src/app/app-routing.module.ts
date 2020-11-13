import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { BusquedaPersonaComponent } from './Parcial2/Componentes/busqueda-persona/busqueda-persona.component';
import { ConsultaVacunaComponent } from './Parcial2/Componentes/consulta-vacuna/consulta-vacuna.component';

const routes: Routes = [
  { path: '', component: InicioComponent },
  { path: 'busqueda-persona', component: BusquedaPersonaComponent },
  { path: 'consulta-persona', component: ConsultaVacunaComponent }
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes)
],
exports: [RouterModule]
})
export class AppRoutingModule { }
