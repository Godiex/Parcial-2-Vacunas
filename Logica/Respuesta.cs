using System;
using System.Collections.Generic;

namespace Logica
{
    public class RespuestaConsulta<G>
    {
        public IList<G> Elementos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public RespuestaConsulta(IList<G> elementos, string mensaje, bool error) {
            Elementos = elementos;
            Mensaje = mensaje;
            Error = error;
        }
        public RespuestaConsulta() {
            Elementos = new List<G>();
        }
    }
    public class Respuesta<G>
    {
        public G Elemento { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public Respuesta(G elemento, string mensaje, bool error) {
            Elemento = elemento;
            Mensaje = mensaje;
            Error = error;
        }
        public Respuesta(G elemento) {
            Elemento = elemento;
        }
    }
}
