import { Component, OnInit } from '@angular/core';
import { PersonaService } from '../../../services/persona.service';
import { Persona } from '../../models/persona';
import { Mensaje } from '../../../services/mensaje';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistroPersonaComponent } from './registro-persona/registro-persona.component';

@Component({
  selector: 'app-busqueda-persona',
  templateUrl: './busqueda-persona.component.html',
  styleUrls: ['./busqueda-persona.component.css']
})
export class BusquedaPersonaComponent implements OnInit {
  formularioRegistro: FormGroup;
  constructor(private servicioPersona: PersonaService, public mensaje: Mensaje, private formBuilder: FormBuilder,private modalService: NgbModal,) { }
  id: string;
  persona: Persona = new Persona();
  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
  }

  buscarPersona()
  {
    this.servicioPersona.buscar(this.id).subscribe(p => {
      if(p.elemento ==null)
      {
        this.AbrirRegistro();
      }
      else{
        this.persona = p.elemento;
      }
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
  get identificacion() {
    return this.formularioRegistro.get('identificacion');
  }

  AbrirRegistro()
  {
    this.modalService.open(RegistroPersonaComponent, { size: 'lg' });
  }
}
