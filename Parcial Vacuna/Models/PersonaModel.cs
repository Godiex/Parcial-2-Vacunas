using Entidad;
namespace ParcialCorte1_ProgWeb.Models
{
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public Apoyo Apoyo { get; set; }

        public PersonaInputModel() {
            Apoyo = new Apoyo();
        }
    }

    public class PersonaViewModel: PersonaInputModel
    {
        public PersonaViewModel() { }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombres = persona.Nombres;
            Apellidos = persona.Apellidos;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            Apoyo = persona.Apoyo;
        }
    }
}
