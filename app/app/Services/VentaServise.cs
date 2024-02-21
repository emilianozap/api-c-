using app.database;
using app.models;
using app.DTOs;
using app.Mapper;

//ObtenerProducto

namespace app.Services
{
    public class VentaService
    {
        private CoderContext context;

        public VentaService(CoderContext coderContext)
        {
            this.context = coderContext;
        }



        public List<Ventum> ObtenerTodosLasVentas()
        {
            return this.context.Venta.ToList();
        }



        public bool AgregarVenta(VentaDTO dto)
        {
            Ventum v = VentaMapper.MapearAVenta(dto);

            this.context.Venta.Add(v);
            this.context.SaveChanges();
            return true;
        }

        public bool BorrarVentaPorId(int id)
        {
            Ventum? venta = this.context.Venta.Where(v => v.Id == id).FirstOrDefault();

            if (venta is not null)
            {
                this.context.Remove(venta);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool ActualizarVentaPorId(int id, VentaDTO ventaDTO)
        {
            Ventum? venta = this.context.Venta.Where(v => v.Id == id).FirstOrDefault();

            if (venta is not null)
            {
                venta.Id = ventaDTO.Id;
                venta.Comentarios = ventaDTO.Comentarios;
                venta.IdUsuario = ventaDTO.IdUsuario;

                this.context.Venta.Update(venta);
                this.context.SaveChanges();
                return true;
            }


            return false;
        }

   

    }
}
