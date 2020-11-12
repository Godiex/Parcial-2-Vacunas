using System;
using System.Collections.Generic;

namespace Logica
{
    public class PeticionConsulta<G>
    {
        public IList<G> Elementos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public PeticionConsulta(IList<G> elementos, string mensaje, bool error) {
            Elementos = elementos;
            Mensaje = mensaje;
            Error = error;
        }
        public PeticionConsulta() {
            Elementos = new List<G>();
        }
    }
    public class Peticion<G>
    {
        public G Elemento { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public Peticion(G elemento, string mensaje, bool error) {
            Elemento = elemento;
            Mensaje = mensaje;
            Error = error;
        }
        public Peticion(G elemento) {
            Elemento = elemento;
        }
    }
}
