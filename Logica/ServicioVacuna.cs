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
            respuesta.Elemento = ObtenerVacunaRegistrada(respuesta.Elemento);
            if (respuesta.Elemento == null)
            {
                respuesta.Error = false;
                respuesta.Mensaje = "Operacion Realizada con exito";
            }
            else
                respuesta = new Respuesta<Vacuna>(null, "La Vacuna que intenta guardar ya se encuentra registrada", true);
            return respuesta;
        }

        public Vacuna ObtenerVacunaRegistrada(Vacuna vacuna)
        {
            return _contexto.Vacunas.Where(v => v.Identificacion == vacuna.Identificacion && v.Nombre.Equals(vacuna.Nombre)).ToList().First();
        }

        public RespuestaConsulta<Vacuna> ObtenerVacunasDePersona(Vacuna vacuna)
        {
            RespuestaConsulta<Vacuna> peticion = new RespuestaConsulta<Vacuna>();
            try
            {
                peticion.Elementos = _contexto.Vacunas.Where(v => v.Identificacion == vacuna.Identificacion).ToList();
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
