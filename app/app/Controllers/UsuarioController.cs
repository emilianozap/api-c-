using app.models;
using app.Services;
using app.database;
using Microsoft.AspNetCore.Mvc;
using app.DTOs;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        [HttpGet]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return this.usuarioService.ObtenerTodosLosUsuarios();
        }










        [HttpPost]
        public IActionResult AgregarUnNuevoUsuario([FromBody] UsuarioDTO usuario)
        {

            if (this.usuarioService.AgregarUsuario(usuario))
            {

                return base.Ok(new { mensaje = "usuario agregado", usuario });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego un usuario" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarUsuario(int id)
        {
            if (id > 0)
            {
                if (this.usuarioService.BorrarUsuarioPorId(id))
                {
                    return base.Ok(new { mensaje = "Producto Usuario", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuarioPorId(int id, UsuarioDTO usuarioDTO)
        {
            if (id > 0)
            {
                if (this.usuarioService.ActualizarUsuarioPorId(id, usuarioDTO))
                {
                    return base.Ok(new { mensaje = "Usuario Actualizado", status = 200, usuarioDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }



    }
}