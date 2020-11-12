export class Peticion<G> {
    constructor (Elemento: G) {
        this.elemento = Elemento;
    }
    elemento: G;
    mensaje: string;
    error: boolean;
}

export class PeticionConsulta<G> {
    elementos: G[] = [];
    mensaje: string;
    error: boolean;
}
