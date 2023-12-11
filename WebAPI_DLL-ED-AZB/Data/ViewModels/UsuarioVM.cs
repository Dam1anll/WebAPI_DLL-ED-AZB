using System.Collections.Generic;

namespace WebAPI_DLL_ED_AZB.Data.ViewModels
{
    public class UsuarioVM
    {
        public string Nombre { get; set; }
        public string ApellidoPa { get; set; }
        public string ApellidoMa { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        public int NumeroCelular { get; set; }
    }
    public class UsuarioWithPlantas 
    {
        public string Nombre { get; set; }
        public string ApellidoPa { get; set; }
        public string ApellidoMa { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        public int NumeroCelular { get; set; }
        public List<string> PlantaNombre { get; set; }
    }
}
