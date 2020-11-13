import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Vacuna } from '../Parcial2/models/vacuna';
import { Respuesta, RespuestaConsulta } from './respuesta';
@Injectable({
  providedIn: 'root'
})
export class VacunaService {
  baseURL: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseURL: string,
  private HandleErrorService: HandleHttpErrorService, private modalService: NgbModal)
  {
    this.baseURL = baseURL;
  }

  Guardar(vacuna: Vacuna): Observable<Respuesta<Vacuna>> {
    return this.http.post<Respuesta<Vacuna>>(this.baseURL + 'api/Vacuna', vacuna).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Respuesta<Vacuna>>('Registrar Vacuna', null))
    );
  }

  Consultar(identificacion : string): Observable<RespuestaConsulta<Vacuna>> {
    return this.http.get<RespuestaConsulta<Vacuna>>(this.baseURL + 'api/Vacuna/'+ identificacion).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<RespuestaConsulta<Vacuna>>('Consultar Vacuna',null))
    );
  }

}
