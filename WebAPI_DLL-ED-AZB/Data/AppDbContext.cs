using WebAPI_DLL_ED_AZB.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace WebAPI_DLL_ED_AZB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario_Planta>()
                .HasOne(b => b.Planta)
                .WithMany(ba => ba.Usuario_Plantas)
                .HasForeignKey(bi => bi.IdPlanta);

            modelBuilder.Entity<Usuario_Planta>()
                .HasOne(b => b.Usuario)
                .WithMany(ba => ba.Usuario_Planta)
                .HasForeignKey(bi => bi.IdUsuario);
        }
        //Este método es para obtener y enviar datos a la bd
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Usuario_Planta> Usuario_Plantas { get; set; }
        public DbSet<Sensor> Sensores { get; set; }

    }
}
