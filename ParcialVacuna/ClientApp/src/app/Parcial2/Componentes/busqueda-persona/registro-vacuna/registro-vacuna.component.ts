import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Vacuna } from 'src/app/Parcial2/models/vacuna';
import { Mensaje } from 'src/app/services/mensaje';
import { VacunaService } from 'src/app/services/vacuna.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-registro-vacuna',
  templateUrl: './registro-vacuna.component.html',
  styleUrls: ['./registro-vacuna.component.css']
})
export class RegistroVacunaComponent implements OnInit {
  formularioRegistro: FormGroup;
  constructor(public mensaje: Mensaje,private servicioVacuna : VacunaService, private formBuilder: FormBuilder,public activeModal: NgbActiveModal) { }
  @Input() identificacion: string;
  vacuna : Vacuna = new Vacuna();
  nombres : string[]= ["Haemophilus","influenzatipo B","Tdpa","DTPa","Hepatitis A","Hepatitis B","virus del papiloma Humano"];
  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
  }

  EstablecerValidacionesFormulario() {
    this.formularioRegistro = this.formBuilder.group(
      {
        fecha: [, [Validators.required]],
        nombre: ['', [Validators.required]]
      }
    );
  }

  get nombre() {
    return this.formularioRegistro.get('nombre');
  }
  get fecha() {
    return this.formularioRegistro.get('fecha');
  }
  registroVacuna ()
  {
    this.vacuna.identificacion = this.identificacion;
    this.servicioVacuna.Guardar(this.vacuna).subscribe(r => {
      this.mensaje.Informar("Registro Vacuna",r.mensaje);
    });
  }
}
