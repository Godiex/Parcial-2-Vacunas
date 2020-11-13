import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Vacuna } from 'src/app/Parcial2/models/vacuna';
import { Mensaje } from 'src/app/services/mensaje';
import { VacunaService } from 'src/app/services/vacuna.service';

@Component({
  selector: 'app-registro-vacuna',
  templateUrl: './registro-vacuna.component.html',
  styleUrls: ['./registro-vacuna.component.css']
})
export class RegistroVacunaComponent implements OnInit {

  constructor(public mensaje: Mensaje,private servicioVacuna : VacunaService, private formBuilder: FormBuilder,public activeModal: NgbActiveModal) { }
  @Input() identificacion: string;
  vacuna : Vacuna = new Vacuna();
  fecha = new Date();
  
  ngOnInit(): void {
  }
  registroVacuna ()
  {
    this.servicioVacuna.Guardar(this.vacuna).subscribe(r => {
      this.mensaje.Informar("Registro Estudiante",r.mensaje);
    });
  }
}
