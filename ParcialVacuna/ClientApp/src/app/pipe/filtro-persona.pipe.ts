import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from '../Parcial2/models/persona';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  transform(personas: Persona[], filtroPersona: string): any {
    if (filtroPersona == null) return personas;
         return personas.filter(p=> p.apellidos.toLowerCase().indexOf(filtroPersona.toLowerCase()) !== -1
         || p.nombres.toLowerCase().indexOf(filtroPersona.toLowerCase()) !== -1);
      }    

}
