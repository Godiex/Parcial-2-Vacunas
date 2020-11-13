using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Entidad
{
    public class Persona
    {
        [Key]
        [Column(TypeName = "nvarchar(11)")]
        public string Identificacion { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string TipoDocumento { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Nombres { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string NombresAcudiente { get; set; }
        [Column(TypeName = "nvarchar(14)")]
        public string Estado { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string NombreInstitucionEducativa { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona()
        {
            Estado = "No Vacunado";
        }
        public int Edad
        {
            get
            {
                int edad = DateTime.Now.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Month > DateTime.Now.Month)
                {
                    --edad;
                }
                return edad;
            }
        }

    }
}
