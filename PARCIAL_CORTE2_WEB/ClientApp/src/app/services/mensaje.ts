import { Injectable, Inject } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';

@Injectable({
  providedIn: 'root'
})
export class Mensaje {
  
  constructor(private modalService: NgbModal) { }

  Informar(titulo: string, mensaje: string) {
    const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = titulo;
        messageBox.componentInstance.message = mensaje;
  }
}