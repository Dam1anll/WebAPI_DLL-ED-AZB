using System.Collections.Generic;

namespace WebAPI_DLL_ED_AZB.Data.Models
{
    public class Planta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int TemperaturaIdeal { get; set; }
        public int HumedadIdeal { get; set; }

        //Propiedades de Navegacion

        public int IdSensor { get; set; }
        public Sensor Sensor { get; set; }
        public List<Usuario_Planta> Usuario_Plantas { get; set; }
    }
}
