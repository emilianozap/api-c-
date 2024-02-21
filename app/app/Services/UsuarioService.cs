using app.database;
using app.DTOs;
using app.Mapper;
using app.models;

//ListarProductos
//CrearProducto
//ModificarProducto
//EliminarProducto

namespace app.Services
{
    public class UsuarioService
    {
        private CoderContext context;
        public UsuarioService(CoderContext coderContext)
        {
            this.context = coderContext;

        }


        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return this.context.Usuarios.ToList();

        }

        public bool AgregarUsuario(UsuarioDTO dto)
        {
            Usuario u = UsuarioMapper.MapearAUsuario(dto);

            this.context.Usuarios.Add(u);
            this.context.SaveChanges();
            return true;
        }


        public bool BorrarUsuarioPorId(int id)
        {
            Usuario? usuario = this.context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            if (usuario is not null)
            {
                this.context.Remove(usuario);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool ActualizarUsuarioPorId(int id, UsuarioDTO usuarioDTO)
        {
            Usuario? usuario = this.context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            if (usuario is not null)
            {
            
                usuario.Nombre = usuarioDTO.Nombre;
                usuario.Id = usuarioDTO.Id;
                usuario.Apellido = usuarioDTO.Apellido;
                usuario.NombreUsuario = usuarioDTO.NombreUsuario;
                usuario.Contraseña = usuarioDTO.Contraseña;
                usuario.Mail = usuarioDTO.Mail;

                this.context.Usuarios.Update(usuario);
                this.context.SaveChanges();
                return true;
            }


            return false;
        }




    }


}
