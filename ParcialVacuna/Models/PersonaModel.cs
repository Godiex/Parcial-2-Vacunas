using System;
using Entidad;
namespace ParcialCorte1_ProgWeb.Models
{
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string NombresAcudiente { get; set; }
        public string NombreInstitucionEducativa { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class PersonaViewModel: PersonaInputModel
    {
        public PersonaViewModel() { }
        public int Edad { get; set; }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombres = persona.Nombres;
            TipoDocumento = persona.TipoDocumento;
            Edad = persona.Edad;
            NombreInstitucionEducativa = persona.NombreInstitucionEducativa;
            NombresAcudiente = persona.NombresAcudiente;
            FechaNacimiento = persona.FechaNacimiento;
        }
    }
}
