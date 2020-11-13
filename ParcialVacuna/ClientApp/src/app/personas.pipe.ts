import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from './Parcial2/models/persona';

@Pipe({
  name: 'personas'
})
export class PersonasPipe implements PipeTransform {

  transform(value: string, personas: Persona[]): any {
    return null;
  }

}
