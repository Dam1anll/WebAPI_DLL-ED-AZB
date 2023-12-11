using System.Collections.Generic;

namespace WebAPI_DLL_ED_AZB.Data.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPa { get; set; }
        public string ApellidoMa { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        public int NumeroCelular { get; set; }
        

        //Propiedades de Navegacion
        public List<Usuario_Planta> Usuario_Planta { get; set; }
    }
}
