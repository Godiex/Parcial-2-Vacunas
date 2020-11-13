using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidad;

namespace Logica
{
    public class ServicioVacuna
    {
        private readonly VacunaContext _contexto;

        public ServicioVacuna(VacunaContext contexto)
        {
            _contexto = contexto;
        }

        public Respuesta<Vacuna> Guardar(Vacuna Vacuna)
        {
            Respuesta<Vacuna> respuesta = new Respuesta<Vacuna>(Vacuna);
            try
            {
                respuesta = EjecutarValidaciones(respuesta);
                if (!respuesta.Error)
                {
                    respuesta.Elemento = Vacuna;
                    Persona persona = _contexto.Personas.Find(Vacuna.Identificacion);
                    persona.Estado = "vacunado";
                    _contexto.Personas.Update(persona);
                    _contexto.Vacunas.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta.Elemento = null;
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
            }
            return respuesta;
        }

        public Respuesta<Vacuna> EjecutarValidaciones(Respuesta<Vacuna> respuesta)
        {
            List<Vacuna> vacunas = ObtenerVacunasRegistrada(respuesta.Elemento);
            
            if (vacunas.Count == 0)
            {
                respuesta.Error = false;
                respuesta.Mensaje = "Operacion Realizada con exito";
            }
            else
            {
                Vacuna vacuna  = vacunas.Where(v => v.Nombre == respuesta.Elemento.Nombre).ToList().First();
                if (vacuna != null)
                {
                    respuesta = new Respuesta<Vacuna>(null, "La Vacuna que intenta guardar ya se encuentra registrada", true);
                }
            }
            respuesta.Error = false;
            respuesta.Mensaje = "Operacion Realizada con exito";
            return respuesta;
        }

        public List<Vacuna> ObtenerVacunasRegistrada(Vacuna vacuna)
        {
            return _contexto.Vacunas.Where(v => v.Identificacion == vacuna.Identificacion).ToList();
        }

        public RespuestaConsulta<Vacuna> ObtenerVacunasDePersona(string  identificacion)
        {
            RespuestaConsulta<Vacuna> peticion = new RespuestaConsulta<Vacuna>();
            try
            {
                peticion.Elementos = _contexto.Vacunas.Where(v => v.Identificacion == identificacion).ToList();
                peticion = (peticion.Elementos.Count != 0) ?
                new RespuestaConsulta<Vacuna>(peticion.Elementos, "Consulta realizada con éxito", false) :
                new RespuestaConsulta<Vacuna>(new List<Vacuna>(), "No se han encontrado Vacunas registradas", true);
            }
            catch (Exception e)
            {
                peticion = new RespuestaConsulta<Vacuna>(new List<Vacuna>(), "Error: " + e.Message, true);
            }
            return peticion;
        }
    }
}
