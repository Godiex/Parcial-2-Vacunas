import { Component, OnInit } from '@angular/core';
import { PersonaService } from '../../../services/persona.service';

@Component({
  selector: 'app-busqueda-persona',
  templateUrl: './busqueda-persona.component.html',
  styleUrls: ['./busqueda-persona.component.css']
})
export class BusquedaPersonaComponent implements OnInit {

  constructor(private servicioPersona: PersonaService) { }

  ngOnInit(): void {
  }

  buscarPersona()
  {

  }
}
