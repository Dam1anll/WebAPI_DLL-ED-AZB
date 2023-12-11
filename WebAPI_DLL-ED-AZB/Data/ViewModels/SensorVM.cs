using System.Collections.Generic;

namespace WebAPI_DLL_ED_AZB.Data.ViewModels
{
    public class SensorVM
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
    }
    public class SensorWithPlantasAndUsuariosVM 
    {
        public string Nombre { get; set; }
        public string Tipo { get; set;}
        public List<PlantaUsarioVM> PlantaUsuarios { get; set;}
    }

    public class PlantaUsarioVM 
    {
        public string PlantaNombre { get; set;}
        public List<string> PlantaUsuarios { get;set;}
    }
}
