using System.Linq;
using System.Collections.Generic;
using System;
using Entidad;
using Datos;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ServicioPersona
    {
        private readonly ParcialContext _contexto;

        public ServicioPersona(ParcialContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<Persona> Guardar(Persona Persona)
        {
            Peticion<Persona> peticion = new Peticion<Persona>(Persona);
            try
            {
                peticion = EjecutarValidaciones(peticion);
                if (peticion.Elemento != null)
                {
                    peticion = new Peticion<Persona>(Persona,$"Los datos de {Persona.Nombres} han sido guardados correctamente",false);
                    peticion.Elemento.Apoyo.Fecha = DateTime.Now.ToString();
                    _contexto.Personas.Add(peticion.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                peticion.Elemento = null;
                peticion.Mensaje = "Error de la aplicación: " + E.Message;
            }
            return peticion;
        }

        public Peticion<Persona> EjecutarValidaciones(Peticion<Persona> peticion)
        {
                Persona persona = peticion.Elemento;
                peticion = BuscarPorIdentificacion(peticion.Elemento.Identificacion);
                if (peticion.Elemento == null)
                {
                    peticion.Elemento = persona;
                    peticion = ValidarMonto(peticion);
                }
                else
                    peticion = new Peticion<Persona>(null,"La persona que intenta guardar ya se encuentra registrada (cédula existente)",true);
            return peticion;
        }
        public Peticion<Persona> BuscarPorIdentificacion(string Identificacion)
        {
            Peticion<Persona> peticion = new Peticion<Persona>(new Persona());
            try
            {
                peticion.Elemento = _contexto.Personas.Find(Identificacion);
                peticion = (peticion.Elemento == null) ? new Peticion<Persona>(null,$"La Persona con cédula numero {Identificacion} no se encuentra registrada",true):
                new Peticion<Persona>(peticion.Elemento,"Persona encontrada",false);
            }
            catch (Exception E)
            {
                peticion = new Peticion<Persona>(null,"Error de la aplicación: " + E.Message,true);
            }
            return peticion;
        }
        public Peticion<Persona> ValidarMonto(Peticion<Persona> peticion)
        {
            decimal Total = TotalizarMonto();
            if (Total + peticion.Elemento.Apoyo.ValorApoyo > 600000000)
                peticion = new Peticion<Persona>(null,"Se ha superado la suma en conjunto del valor máximo de las ayudas: 600.000.000",true);
            return peticion;
        }
        public PeticionConsulta<Persona> ConsultarTodos()
        {
            PeticionConsulta<Persona> peticion = new PeticionConsulta<Persona>();
            try
            {
                peticion.Elementos = _contexto.Personas.Include(p => p.Apoyo).ToList();
                peticion = (peticion.Elementos.Count != 0)? 
                new PeticionConsulta<Persona>(peticion.Elementos,"Consulta realizada con éxito",false):
                new PeticionConsulta<Persona>(new List<Persona>(),"No se han encontrado Personas registradas",true);
            }
            catch (Exception e)
            {
                peticion = new PeticionConsulta<Persona>(new List<Persona>(),"Error: " + e.Message,true);
            }
            return peticion;
        }
        public decimal TotalizarMonto()
        {
            return _contexto.Personas.Sum(p=>p.Apoyo.ValorApoyo);
        }
    }
}