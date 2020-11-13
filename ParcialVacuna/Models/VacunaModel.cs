using System;
using Entidad;
namespace ParcialCorte1_ProgWeb.Models
{
    public class VacunaInputModel
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class VacunaViewModel: VacunaInputModel
    {
        public VacunaViewModel() { }
        
        public int VacunaId { get; set; }
        public VacunaViewModel(Vacuna vacuna)
        {
            Nombre = vacuna.Nombre;
            Identificacion = vacuna.Identificacion;
            Fecha = vacuna.Fecha;
            VacunaId = vacuna.VacunaId;
        }
    }
}
