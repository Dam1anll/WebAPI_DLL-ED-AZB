using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;

namespace WebAPI_DLL_ED_AZB.Data.ViewModels
{
    public class PlantaVM
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int TemperaturaIdeal { get; set; }
        public int HumedadIdeal { get; set; }
        public List<int> IDsUsuario { get; set; }
    }

    public class PlantaWithUsuarioVM
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int TemperaturaIdeal { get; set; }
        public int HumedadIdeal { get; set; }
        public string SensorNombre { get; set; }
        public List<string> UsuarioNames { get; set; }
    }
}
