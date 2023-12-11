using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPI_DLL_ED_AZB.Data.Services;
using WebAPI_DLL_ED_AZB.Data.ViewModels;
using System;

namespace WebAPI_DLL_ED_AZB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        public PlantasServices _plantasService;

        public PlantasController(PlantasServices plantasService)
        {
            _plantasService = plantasService;
        }
        [HttpGet("get-all-plantas")]
        public IActionResult GetAllPlantas()
        {
            try
            {
                var allplantas = _plantasService.GetAllPts();
                return Ok(allplantas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener todas las plantas: {ex.Message}");
            }
        }
        [HttpGet("get-planta-by-id/{id}")]
        public IActionResult GetPlantaById(int id)
        {
            try
            {
                var planta = _plantasService.GetPlantaById(id);
                if (planta != null)
                {
                    return Ok(planta);
                }
                else
                {
                    return NotFound($"No se encontró una planta con ID: {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener planta: {ex.Message}");
            }
        }
        [HttpPost("add-planta-with-usuarios")]
        public IActionResult AddPlanta([FromBody] PlantaVM planta)
        {
            try
            {
                _plantasService.AddPlantaWithUsuarioss(planta);
                return Created(nameof(AddPlanta), new { Message = "Planta creada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al agregar planta: {ex.Message}");
            }
        }
        [HttpPut("update-planta-by-id/{id}")]
        public IActionResult UpdatePlantaById(int id, [FromBody] PlantaVM planta)
        {
            try
            {
                var updatePlanta = _plantasService.UpdatePlantaByID(id, planta);
                return Ok(updatePlanta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar planta: {ex.Message}");
            }
        }
        [HttpDelete("delete-planta-by-id/{id}")]
        public IActionResult DeletePlantaByID(int id)
        {
            try
            {
                _plantasService.DeletePlantaByID(id);
                return Ok($"Planta con ID {id} eliminada exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar planta: {ex.Message}");
            }
        }
    }
}
