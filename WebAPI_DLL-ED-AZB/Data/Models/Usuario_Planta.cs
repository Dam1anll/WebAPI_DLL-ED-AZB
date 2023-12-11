namespace WebAPI_DLL_ED_AZB.Data.Models
{
    public class Usuario_Planta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdPlanta { get; set; }
        public Planta Planta { get; set; }
    }
}
