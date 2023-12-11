using WebAPI_DLL_ED_AZB.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using System;
using System.Linq;

namespace WebAPI_DLL_ED_AZB.Data
{
    public class AppDbInitialer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Plantas.Any())
                {
                    context.Plantas.AddRange(new Planta()
                    {
                        Nombre = "Nombre1",
                        Tipo = "Tipo1",
                        TemperaturaIdeal = 0,
                        HumedadIdeal = 0
                    },
                     new Planta()
                     {
                         Nombre = "Nombre2",
                         Tipo = "Tipo2",
                         TemperaturaIdeal = 0,
                         HumedadIdeal = 0
                     });
                    context.SaveChanges();
                }
            }
        }
    }
}
