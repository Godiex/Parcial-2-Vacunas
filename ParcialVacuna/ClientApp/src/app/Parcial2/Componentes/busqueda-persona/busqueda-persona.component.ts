import { Component, OnInit } from '@angular/core';
import { PersonaService } from '../../../services/persona.service';
import { Persona } from '../../models/persona';
import { Mensaje } from '../../../services/mensaje';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-busqueda-persona',
  templateUrl: './busqueda-persona.component.html',
  styleUrls: ['./busqueda-persona.component.css']
})
export class BusquedaPersonaComponent implements OnInit {
  formularioRegistro: FormGroup;
  constructor(private servicioPersona: PersonaService, public mensaje: Mensaje, private formBuilder: FormBuilder) { }
  identificacion: string;
  persona: Persona = new Persona();
  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
  }

  buscarPersona()
  {
    this.servicioPersona.buscar(this.identificacion).subscribe(p => {
      this.persona = p.elemento;
      this.mensaje.Informar("Busqueda Persona", p.mensaje);
    });
  }

  EstablecerValidacionesFormulario() {
    this.formularioRegistro = this.formBuilder.group(
      {
        identificacion: ['', [Validators.required, Validators.minLength(10)]]
      }
    );
  }
}
