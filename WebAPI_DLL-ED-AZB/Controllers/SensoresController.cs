using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI_DLL_ED_AZB.Data.Models;
using WebAPI_DLL_ED_AZB.Data.Services;
using WebAPI_DLL_ED_AZB.Exceptions;
using WebAPI_DLL_ED_AZB.Data.ViewModels;
using System.Security.Policy;

namespace WebAPI_DLL_ED_AZB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private SensoresServiecs _sensoresServices;

        public SensoresController(SensoresServiecs sensoresService)
        {
            _sensoresServices = sensoresService;
        }

        public IActionResult AddSensor([FromBody] SensorVM sensor)
        {
            try
            {
                var newSensor = _sensoresServices.AddSensor(sensor);
                return Created(nameof(AddSensor), newSensor);
            }
            catch (SensorAgregarException ex)
            {
                return BadRequest($"Error específico del controlador al agregar sensor: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("get-all-sensores")]
        public IActionResult GetAllSensores()
        {
            var sensores = _sensoresServices.GetAllSensores();
            return Ok(sensores);
        }

        [HttpGet("get-sensor-by-id/{id}")]
        public IActionResult GetSensorById(int id)
        {
            try
            {
                var response = _sensoresServices.GetSensorByID(id);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound($"No se encontró un sensor con ID: {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener sensor: {ex.Message}");
            }
        }

        [HttpGet("get-sensores-plantas-with-usuarios/{id}")]
        public IActionResult GetSensorData(int id)
        {
            try
            {
                var response = _sensoresServices.GetSensorData(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener datos del sensor: {ex.Message}");
            }
        }

        [HttpDelete("delete-sensor-by-id/{id}")]
        public IActionResult DeleteSensorById(int id)
        {
            try
            {
                _sensoresServices.DeleteSensorById(id);
                return Ok($"Sensor con ID {id} eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar sensor: {ex.Message}");
            }
        }
    }
}
