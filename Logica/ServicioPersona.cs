using System.Linq;
using System.Collections.Generic;
using System;
using Entidad;
using Microsoft.EntityFrameworkCore;
using Datos;

namespace Logica
{
    public class ServicioPersona
    {
        private readonly VacunaContext _contexto;
        
        public ServicioPersona(VacunaContext contexto)
        {
            _contexto = contexto;
        }

        public Respuesta<Persona> Guardar(Persona Persona)
        {
            Respuesta<Persona> respuesta = new Respuesta<Persona>(Persona);
            try
            {
                respuesta = EjecutarValidaciones(respuesta);
                if (respuesta.Elemento != null)
                {
                    respuesta = new Respuesta<Persona>(Persona,$"Los datos de {Persona.Nombres} han sido guardados correctamente",false);
                    _contexto.Personas.Add(respuesta.Elemento);
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

        public Respuesta<Persona> EjecutarValidaciones(Respuesta<Persona> respuesta)
        {
                Persona persona = respuesta.Elemento;
            respuesta = BuscarPorIdentificacion(respuesta.Elemento.Identificacion);
                if (respuesta.Elemento == null)
                {
                    respuesta.Elemento = persona;
                }
                else
                respuesta = new Respuesta<Persona>(null,"La persona que intenta guardar ya se encuentra registrada (cédula existente)",true);
            return respuesta;
        }
        public Respuesta<Persona> BuscarPorIdentificacion(string Identificacion)
        {
            Respuesta<Persona> peticion = new Respuesta<Persona>(new Persona());
            try
            {
                peticion.Elemento = _contexto.Personas.Find(Identificacion);
                peticion = (peticion.Elemento == null) ? new Respuesta<Persona>(null,$"La Persona con cédula numero {Identificacion} no se encuentra registrada",true):
                new Respuesta<Persona>(peticion.Elemento,"Persona encontrada",false);
            }
            catch (Exception E)
            {
                peticion = new Respuesta<Persona>(null,"Error de la aplicación: " + E.Message,true);
            }
            return peticion;
        }

        
        

        public RespuestaConsulta<Persona> ConsultarTodos()
        {
            RespuestaConsulta<Persona> peticion = new RespuestaConsulta<Persona>();
            try
            {
                peticion.Elementos = _contexto.Personas.ToList();
                peticion = (peticion.Elementos.Count != 0)? 
                new RespuestaConsulta<Persona>(peticion.Elementos,"Consulta realizada con éxito",false):
                new RespuestaConsulta<Persona>(new List<Persona>(),"No se han encontrado Personas registradas",true);
            }
            catch (Exception e)
            {
                peticion = new RespuestaConsulta<Persona>(new List<Persona>(),"Error: " + e.Message,true);
            }
            return peticion;
        }
        public RespuestaConsulta<Persona> ConsultarVacunados()
        {
            RespuestaConsulta<Persona> peticion = new RespuestaConsulta<Persona>();
            try
            {
                peticion.Elementos = _contexto.Personas.Where(v =>v.Estado.Equals("vacunado")).ToList();
                peticion = (peticion.Elementos.Count != 0) ?
                new RespuestaConsulta<Persona>(peticion.Elementos, "Consulta realizada con éxito", false) :
                new RespuestaConsulta<Persona>(new List<Persona>(), "No se han encontrado Personas vacunadas", true);
            }
            catch (Exception e)
            {
                peticion = new RespuestaConsulta<Persona>(new List<Persona>(), "Error: " + e.Message, true);
            }
            return peticion;
        }
    }
}