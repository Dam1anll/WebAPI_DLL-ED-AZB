using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_DLL_ED_AZB.Data.ViewModels;
using WebAPI_DLL_ED_AZB.Data.Services;
using System;

namespace WebAPI_DLL_ED_AZB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuariosServices _usuariosService;

        public UsuariosController(UsuariosServices usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpPost("add-usuario")]
        public IActionResult AddUsuario([FromBody] UsuarioVM usuario)
        {
            try
            {
                _usuariosService.AddUsuario(usuario);
                return Created(nameof(AddUsuario), new { Message = "Usuario creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al agregar usuario: {ex.Message}");
            }
        }

        [HttpPut("update-usuario/{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] UsuarioVM usuario)
        {
            try
            {
                var usuarioActualizado = _usuariosService.UpdateUsuarioById(id, usuario);

                if (usuarioActualizado != null)
                {
                    return Ok($"Usuario con ID {id} actualizado exitosamente.");
                }
                else
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar usuario: {ex.Message}");
            }
        }

        [HttpGet("get-usaurio-with-plantas-by-id")]
        public IActionResult GetUsuarioWithPlantas(int id)
        {
            try
            {
                var response = _usuariosService.GetUsuarioWithPlantas(id);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound($"No se encontró un usuario con ID: {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener usuario: {ex.Message}");
            }
        }
        [HttpGet("get-all-usuarios")]
        public IActionResult GetAllUsuarios()
        {
            var usuarios = _usuariosService.GetAllUsuarios();
            return Ok(usuarios);
        }
        [HttpDelete("delete-usuario-by-id/{id}")]
        public IActionResult DeleteUsuarioById(int id)
        {
            try
            {
                _usuariosService.DeleteUsuarioById(id);
                return Ok($"Usuario con ID {id} eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar usuario: {ex.Message}");
            }
        }
    }
}
