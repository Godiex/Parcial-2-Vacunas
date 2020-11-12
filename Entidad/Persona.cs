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
        [Column(TypeName = "nvarchar(40)")]
        public string NombreInstitucionEducativa { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
