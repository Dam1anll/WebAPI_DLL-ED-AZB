using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_DLL_ED_AZB.Data;
using WebAPI_DLL_ED_AZB.Data.ViewModels;
using WebAPI_DLL_ED_AZB.Data.Models;
using WebAPI_DLL_ED_AZB.Exceptions;

namespace WebAPI_DLL_ED_AZB.Data.Services
{
    public class PlantasServices
    {
        private AppDbContext _context;
        public PlantasServices(AppDbContext context)
        {
            _context = context;

        }

        public void AddPlantaWithUsuarioss(PlantaVM planta)
        {
            try
            {
                var _planta = new Planta()
                {
                    Nombre = planta.Nombre,
                    Tipo = planta.Tipo,
                    TemperaturaIdeal = planta.TemperaturaIdeal,
                    HumedadIdeal = planta.HumedadIdeal
                };

                _context.Plantas.Add(_planta);
                _context.SaveChanges();

                foreach (var id in planta.IDsUsuario)
                {
                    var _planta_usuario = new Usuario_Planta()
                    {
                        IdPlanta = _planta.Id,
                        IdUsuario = id
                    };

                    _context.Usuario_Plantas.Add(_planta_usuario);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PlantaAgregarException("Error al agregar la planta con usuarios.", ex);
            }
        }
        public List<Planta> GetAllPts() => _context.Plantas.ToList();

        public PlantaWithUsuarioVM GetPlantaById(int idplanta)
        {
            var _plantasWithUsuarios = _context.Plantas.Where(n => n.Id == idplanta).Select(planta => new PlantaWithUsuarioVM()
            {
                Nombre = planta.Nombre,
                Tipo = planta.Tipo,
                TemperaturaIdeal  = planta.TemperaturaIdeal,
                HumedadIdeal = planta.HumedadIdeal,
                SensorNombre = planta.Sensor.Tipo,
                UsuarioNames = planta.Usuario_Plantas.Select(n => n.Usuario.Nombre).ToList()
            }).FirstOrDefault();
            return _plantasWithUsuarios;
        }
        public Planta UpdatePlantaByID(int idplanta, PlantaVM planta)
        {
            var _planta = _context.Plantas.FirstOrDefault(n => n.Id == idplanta);

            if (_planta != null)
            {
                _planta.Nombre = planta.Nombre;
                _planta.Tipo = planta.Tipo;
                _planta.TemperaturaIdeal = planta.TemperaturaIdeal;
                _planta.HumedadIdeal = planta.HumedadIdeal;

                _context.SaveChanges();
            }

            return _planta;
        }
        public void DeletePlantaByID(int idplanta)
        {
            var _planta = _context.Plantas.FirstOrDefault(n => n.Id == idplanta);

            if (_planta != null)
            {
                _context.Plantas.Remove(_planta);
                _context.SaveChanges();
            }
        }
    }
}
