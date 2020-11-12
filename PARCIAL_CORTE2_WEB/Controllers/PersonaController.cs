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
        public PersonaController(ParcialContext contexto)
        {
            _servicioPersona = new ServicioPersona(contexto);
        }

        [HttpGet("{formulario}")]
        public object SeleccionarConsulta(string formulario)
        {
            if (formulario == "Consulta")
            {
                return Consultar();
            }
            else
            {
                return TotalizarMonto();
            }
        }
        private ActionResult<PeticionConsulta<PersonaViewModel>> Consultar()
        {
            var peticion = _servicioPersona.ConsultarTodos();
            return Ok(peticion);
        }
        
        private decimal TotalizarMonto()
        {
            return _servicioPersona.TotalizarMonto();
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<Peticion<PersonaViewModel>> Guardar(PersonaInputModel personaInput)
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
            persona.Apellidos = personaInput.Apellidos;
            persona.Edad = personaInput.Edad;
            persona.Sexo = personaInput.Sexo;
            persona.Departamento = personaInput.Departamento;
            persona.Ciudad = personaInput.Ciudad;
            persona.Apoyo.ValorApoyo = personaInput.Apoyo.ValorApoyo;
            persona.Apoyo.Modalidad = personaInput.Apoyo.Modalidad;
            return persona;
        }
    }
}
