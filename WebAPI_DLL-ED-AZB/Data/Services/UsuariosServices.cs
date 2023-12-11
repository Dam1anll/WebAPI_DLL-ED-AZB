using WebAPI_DLL_ED_AZB.Data.Models;
using WebAPI_DLL_ED_AZB.Data.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using WebAPI_DLL_ED_AZB.Exceptions;

namespace WebAPI_DLL_ED_AZB.Data.Services
{
    public class UsuariosServices
    {
        private AppDbContext _context;
        public UsuariosServices(AppDbContext context)
        {
            _context = context;
        }

        public void AddUsuario(UsuarioVM usuario)
        {
            try 
            {
                var _usuario = new Usuario()
                {
                    Nombre = usuario.Nombre,
                    ApellidoPa = usuario.ApellidoPa,
                    ApellidoMa = usuario.ApellidoMa,
                    Rol = usuario.Rol,
                    Correo = usuario.Correo,
                    NumeroCelular = usuario.NumeroCelular
                };

                _context.Usuarios.Add(_usuario);
                _context.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw new UsuarioAgregarException("Error al agregar el usuario.", ex);
            }
        }

        public Usuario UpdateUsuarioById(int idUsuario, UsuarioVM usuario)
        {
            var _usuario = _context.Usuarios.FirstOrDefault(n => n.Id == idUsuario);

            if (_usuario != null)
            {
                _usuario.Nombre = usuario.Nombre;
                _usuario.ApellidoPa = usuario.ApellidoPa;
                _usuario.ApellidoMa = usuario.ApellidoMa;
                _usuario.Rol = usuario.Rol;
                _usuario.Correo = usuario.Correo;
                _usuario.NumeroCelular = usuario.NumeroCelular;

                _context.SaveChanges();
            }

            return _usuario;
        }

        public UsuarioWithPlantas GetUsuarioWithPlantas(int Idusuario)
        {
            var _usuario = _context.Usuarios.Where(n => n.Id == Idusuario).Select(n => new UsuarioWithPlantas()
            {
                Nombre = n.Nombre,
                PlantaNombre = n.Usuario_Planta.Select(n => n.Planta.Tipo).ToList(),
            }).FirstOrDefault();
            return _usuario;
        }
        public List<Usuario> GetAllUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();

            return usuarios;
        }
        public void DeleteUsuarioById(int idUsuario)
        {
            var _usuario = _context.Usuarios.FirstOrDefault(n => n.Id == idUsuario);

            if (_usuario != null)
            {
                _context.Usuarios.Remove(_usuario);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El usuario con id: {idUsuario}, no existe");
            }
        }
    }
}
