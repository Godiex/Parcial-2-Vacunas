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

        [Column(TypeName = "nvarchar(30)")]
        public string Nombres { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Apellidos { get; set; }

        public int Edad { get; set; }

        [Column(TypeName = "nvarchar(9)")]
        public string Sexo { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string Departamento { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string Ciudad { get; set; }

        public Apoyo Apoyo { get; set; }

        public Persona() {
            Apoyo = new Apoyo();
        }
    }
}
