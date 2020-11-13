import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { EncabezadoComponent } from './encabezado/encabezado.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { BusquedaPersonaComponent } from './Parcial2/Componentes/busqueda-persona/busqueda-persona.component';
import { RegistroPersonaComponent } from './Parcial2/Componentes/busqueda-persona/registro-persona/registro-persona.component';
import { RegistroVacunaComponent } from './Parcial2/Componentes/busqueda-persona/registro-vacuna/registro-vacuna.component';
import { ConsultaVacunaComponent } from './Parcial2/Componentes/consulta-vacuna/consulta-vacuna.component';
import { PersonasPipe } from './personas.pipe';

@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    EncabezadoComponent,
    NavMenuComponent,
    FooterComponent,
    AlertModalComponent,
    BusquedaPersonaComponent,
    RegistroPersonaComponent,
    RegistroVacunaComponent,
    ConsultaVacunaComponent,
    PersonasPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule
  ],
  entryComponents: [AlertModalComponent,RegistroPersonaComponent,RegistroVacunaComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
