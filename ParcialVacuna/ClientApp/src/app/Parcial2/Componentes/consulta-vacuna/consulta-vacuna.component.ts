import { Component, OnInit } from '@angular/core';
import { Mensaje } from 'src/app/services/mensaje';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../../models/persona';

@Component({
  selector: 'app-consulta-vacuna',
  templateUrl: './consulta-vacuna.component.html',
  styleUrls: ['./consulta-vacuna.component.css']
})
export class ConsultaVacunaComponent implements OnInit {

  constructor(private servicioPersona: PersonaService,public  mensaje: Mensaje) { }
  personas : Persona [] = [];
  cantidadVacunados : number;
  ngOnInit(): void {
    this.ConsultarPersonas()
    this.ObtenerCantidad();
  }

  ConsultarPersonas()
  {
    this.servicioPersona.Consultar().subscribe(p => {
      if(p.error)
      {
        this.mensaje.Informar("error",p.mensaje);
      }
      else{
        this.personas = p.elementos;
      }
    });
  }
  ObtenerCantidad()
  {
    this.servicioPersona.Consultar().subscribe(p => {
      this.cantidadVacunados =  p.elementos.length;
    });
  }

}
