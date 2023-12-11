using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading;
using WebAPI_DLL_ED_AZB.Data.Models;
using WebAPI_DLL_ED_AZB.Data.ViewModels;
using WebAPI_DLL_ED_AZB.Exceptions;

namespace WebAPI_DLL_ED_AZB.Data.Services
{
    public class SensoresServiecs
    {
        private AppDbContext _context;
        public SensoresServiecs(AppDbContext context)
        {
            _context = context;
        }

        public Sensor AddSensor(SensorVM sensor)
        {
            if (StringStartsWithNumber(sensor.Tipo)) throw new SensorTipoException("El Nombre del sensor empieza por una letra",
                sensor.Tipo);
            var _sensores = new Sensor()
            {
                Nombre = sensor.Tipo,
                Tipo = sensor.Tipo
            };
            _context.Sensores.Add(_sensores);
            _context.SaveChanges();

            return _sensores;
        }
        public List<Sensor> GetAllSensores()
        {
            var sensores = _context.Sensores.ToList();

            return sensores;
        }

        public Sensor GetSensorByID(int id) => _context.Sensores.FirstOrDefault(n => n.Id == id);
        public SensorWithPlantasAndUsuariosVM GetSensorData(int Idsensor)
        {
            var _sensorData = _context.Sensores.Where(n => n.Id == Idsensor).
                Select(n => new SensorWithPlantasAndUsuariosVM()
                {
                    Nombre = n.Nombre,
                    PlantaUsuarios = n.Plantas.Select(n => new PlantaUsarioVM()
                    {
                        PlantaNombre = n.Nombre,
                        PlantaUsuarios = n.Usuario_Plantas.Select(n => n.Usuario.Nombre).ToList(),
                    }).ToList(),
                }).FirstOrDefault();
            return _sensorData;
        }

        public void DeleteSensorById(int id)
        {
            var _sensor = _context.Sensores.FirstOrDefault(n => n.Id == id);

            if (_sensor != null)
            {
                _context.Sensores.Remove(_sensor);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El sensor con id: {id}, no existe");
            }
        }
        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
