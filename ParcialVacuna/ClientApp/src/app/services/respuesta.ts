export class Respuesta<G> {
    constructor (Elemento: G) {
        this.elemento = Elemento;
    }
    elemento: G;
    mensaje: string;
    error: boolean;
}

export class RespuestaConsulta<G> {
    elementos: G[] = [];
    mensaje: string;
    error: boolean;
}
