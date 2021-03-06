import { Component, OnInit } from '@angular/core';
import { PersonaService } from '../../../../services/persona.service';
import { Mensaje } from '../../../../services/mensaje';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Persona } from 'src/app/Parcial2/models/persona';

@Component({
  selector: 'app-registro-persona',
  templateUrl: './registro-persona.component.html',
  styleUrls: ['./registro-persona.component.css']
})
export class RegistroPersonaComponent implements OnInit {
  formularioRegistro: FormGroup;
  constructor(private servicioPersona: PersonaService, public mensaje: Mensaje, private formBuilder: FormBuilder,public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
  }
  persona : Persona = new Persona();
  EstablecerValidacionesFormulario() {
    this.formularioRegistro = this.formBuilder.group(
      {
        identificacion: ['', [Validators.required, Validators.minLength(10)]],
        tipoDocumento: ['', [Validators.required, Validators.minLength(1)]],
        nombres: ['', [Validators.required, Validators.minLength(10)]],
        nombresAcudiente: ['', [Validators.required, Validators.minLength(1)]],
        fechaNacimiento: [, [Validators.required]],
        nombreInstitucionEducativa: ['', [Validators.required, Validators.minLength(1)]]
      }
    );
  }
  get identificacion() {
    return this.formularioRegistro.get('identificacion');
  }
  get tipoDocumento() {
    return this.formularioRegistro.get('tipoDocumento');
  }
  get nombres() {
    return this.formularioRegistro.get('nombres');
  }
  get nombresAcudiente() {
    return this.formularioRegistro.get('nombresAcudiente');
  }
  get fechaNacimiento() {
    return this.formularioRegistro.get('fechaNacimiento');
  }
  get nombreInstitucionEducativa() {
    return this.formularioRegistro.get('nombreInstitucionEducativa');
  }
  registroPersona ()
  {
    this.servicioPersona.Guardar(this.persona).subscribe(r => {
      this.mensaje.Informar("Registro Estudiante",r.mensaje);
    });
  }

}
