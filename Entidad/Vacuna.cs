using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidad
{
    public class Vacuna
    {
        public int VacunaId  { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string Identificacion { get; set; }
    }
}
