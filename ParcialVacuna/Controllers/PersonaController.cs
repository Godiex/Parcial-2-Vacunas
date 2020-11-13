using System.Reflection.Metadata;
using System;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ParcialCorte1_ProgWeb.Models;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos;

namespace ParcialCorte2_ProgWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ServicioPersona _servicioPersona;
        public PersonaController(VacunaContext contexto)
        {
            _servicioPersona = new ServicioPersona(contexto);
        }

        [HttpGet]
        public ActionResult<RespuestaConsulta<PersonaViewModel>> ConsultarVacunados()
        {
            var peticion = _servicioPersona.ConsultarVacunados();
            return Ok(peticion);
        }
        [HttpGet("{identificacion}")]
        public ActionResult<RespuestaConsulta<PersonaViewModel>> BuscarPersona(string identificacion)
        {
            var peticion = _servicioPersona.BuscarPorIdentificacion(identificacion);
            return Ok(peticion);
        }

        // POST: api/Persona
        [HttpPost]
        public ActionResult<Respuesta<PersonaViewModel>> Guardar(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var peticion = _servicioPersona.Guardar(persona);
            return Ok(peticion);
        }

        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona();
            persona.Identificacion = personaInput.Identificacion;
            persona.Nombres = personaInput.Nombres;
            persona.FechaNacimiento = personaInput.FechaNacimiento;
            persona.NombreInstitucionEducativa = personaInput.NombreInstitucionEducativa;
            persona.NombresAcudiente = personaInput.NombresAcudiente;
            persona.TipoDocumento = personaInput.TipoDocumento;
            return persona;
        }
    }
}
