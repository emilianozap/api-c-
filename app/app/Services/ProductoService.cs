using app.database;
using app.models;
using app.DTOs;
using app.Mapper;

//ObtenerProducto

namespace app.Services
{
    public class ProductoService
    {
        private CoderContext context;

        public ProductoService(CoderContext coderContext)
        {
            this.context = coderContext;
        }



        public List<Producto> ObtenerTodosLosProductos()
        {
            return this.context.Productos.ToList();
        }

     

        public bool AgregarUnProducto(ProductoDTO dto)
        {
            Producto p = ProductoMapper.MapearAProducto(dto);

            this.context.Productos.Add(p);
            this.context.SaveChanges();
            return true;
        }

        public bool BorrarProductoPorId(int id)
        {
            Producto? producto = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();

            if (producto is not null)
            {
                this.context.Remove(producto);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool ActualizarProductoPorId(int id, ProductoDTO productoDTO)
        {
            Producto? producto = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();

            if (producto is not null)
            {
                producto.PrecioVenta = productoDTO.PrecioVenta;
                producto.Stock = productoDTO.Stock;
                producto.Descripciones = productoDTO.Descripciones;
                producto.IdUsuario = productoDTO.IdUsuario;
                producto.Costo = productoDTO.Costo;

                this.context.Productos.Update(producto);
                this.context.SaveChanges();
                return true;
            }


            return false;
        }

        //public Producto ObtenerProducto(int id, ProductoService producto)
        //{
        //    {
        //        Producto? productoBuscado = context.Productos.Where(product => product.Id == id).FirstOrDefault();
        //        return productoBuscado;
        //    }
        //}

    }
}
