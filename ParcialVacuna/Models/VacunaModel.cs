using System;
using Entidad;
namespace ParcialCorte1_ProgWeb.Models
{
    public class VacunaInputModel
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
    }

    public class VacunaViewModel: VacunaInputModel
    {
        public VacunaViewModel() { }
        public DateTime Fecha { get; set; }
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
