import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Persona } from '../Parcial2/models/persona';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Respuesta, RespuestaConsulta } from './respuesta';
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

  Guardar(persona: Persona): Observable<Respuesta<Persona>> {
    return this.http.post<Respuesta<Persona>>(this.baseURL + 'api/Persona', persona).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Respuesta<Persona>>('Registrar Persona', null))
    );
  }

  Consultar(): Observable<RespuestaConsulta<Persona>> {
    return this.http.get<RespuestaConsulta<Persona>>(this.baseURL + 'api/Persona').pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<RespuestaConsulta<Persona>>('Consultar Persona',null))
    );
  }

  buscar(identificacion :string): Observable<Respuesta<Persona>> {
    return this.http.get<Respuesta<Persona>>(this.baseURL + 'api/Persona/' + identificacion).pipe(
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Respuesta<Persona>>('buscar Persona', null))
    );
  }

}
