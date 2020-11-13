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
    public class VacunaController : ControllerBase
    {
        private readonly ServicioVacuna _servicioVacuna;
        public VacunaController(VacunaContext contexto)
        {
            _servicioVacuna = new ServicioVacuna(contexto);
        }

        [HttpGet]
        public ActionResult<RespuestaConsulta<PersonaViewModel>> ConsultarVacunados(string identificacion)
        {
            var peticion = _servicioVacuna.ObtenerVacunasDePersona();
            return Ok(peticion);
        }
        
        // POST: api/Persona
        [HttpPost]
        public ActionResult<Respuesta<PersonaViewModel>> Guardar(VacunaInputModel vacunaInput)
        {
            Vacuna vacuna = MapearVacuna(vacunaInput);
            var peticion = _servicioVacuna.Guardar(vacuna);
            return Ok(peticion);
        }

        private Vacuna MapearVacuna(VacunaInputModel vacunaInput)
        {
            var vacuna = new Vacuna();
            vacuna.Nombre = vacunaInput.Nombre;
            vacuna.Fecha = DateTime.Now;
            vacuna.Identificacion = vacunaInput.Identificacion;
            return vacuna;
        }
    }
}
