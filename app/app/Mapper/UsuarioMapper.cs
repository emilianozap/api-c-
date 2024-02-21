using app.DTOs;
using app.models;

namespace app.Mapper
{
    public static class UsuarioMapper
    {
        public static Usuario MapearAUsuario(UsuarioDTO dto)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = dto.Nombre;
            usuario.Id = dto.Id;
            usuario.Apellido = dto.Apellido;
            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Contraseña = dto.Contraseña;
            usuario.Mail = dto.Mail;

            return usuario;
        }

        public static UsuarioDTO MapearADTO(Usuario usuario)
        {
            UsuarioDTO dto = new UsuarioDTO();

            dto.Nombre = usuario.Nombre;
            dto.Id = usuario.Id;
            dto.Apellido = usuario.Apellido;
            dto.NombreUsuario = usuario.NombreUsuario;
            dto.Contraseña= usuario.Contraseña;
            dto.Mail = usuario.Mail;

            return dto;
        }
    }
}
