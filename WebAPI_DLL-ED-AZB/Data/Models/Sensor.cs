using System.Collections.Generic;
using System.Data;

namespace WebAPI_DLL_ED_AZB.Data.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }    

        //Propiedades de Navigacion
        public List<Planta> Plantas { get; set;}
    }
}
