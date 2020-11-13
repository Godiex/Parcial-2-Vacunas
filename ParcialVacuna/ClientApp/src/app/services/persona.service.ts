import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Persona } from '../Parcial2/models/persona';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Peticion, PeticionConsulta } from './peticion';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseURL: string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseURL: string, 
  private HandleErrorService: HandleHttpErrorService, private modalService: NgbModal)
  {
    this.baseURL = baseURL;
  }

  Guardar(persona: Persona): Observable<Peticion<Persona>> {
    return this.http.post<Peticion<Persona>>(this.baseURL + 'api/Persona', persona).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Peticion<Persona>>('Registrar Persona', null))
    );
  }

  Consultar(formulario: string): Observable<PeticionConsulta<Persona>> {
    return this.http.get<PeticionConsulta<Persona>>(this.baseURL + 'api/Persona/' + formulario).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<PeticionConsulta<Persona>>('Consultar Persona',null))
    );
  }

  Totalizar(formulario: string): Observable<number> {
    return this.http.get<number>(this.baseURL + 'api/Persona/' + formulario).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<number>('Totalizar Ayudas',null))
    );
  }
}