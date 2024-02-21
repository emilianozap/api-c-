using app.database;
using app.DTOs;
using app.Mapper;
using app.models;

namespace app.Services
{
    public class ProductoVendidoService
    {
        private CoderContext context;

        public ProductoVendidoService(CoderContext coderContext)
        {
            this.context = coderContext;
        }



        public List<ProductoVendido> ObtenerTodosLosProductosVendidos()
        {
            return this.context.ProductoVendidos.ToList();
        }



        public bool AgregarUnProductoVendido(ProductoVendidoDTO dto)
        {
            ProductoVendido p = ProductoVendidoMapper.MapearAProductoVendido(dto);

            this.context.ProductoVendidos.Add(p);
            this.context.SaveChanges();
            return true;
        }

        public bool BorrarProductoVendidoPorId(int id)
        {
            ProductoVendido? productoVendido = this.context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();

            if (productoVendido is not null)
            {
                this.context.Remove(productoVendido);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool ActualizarProductoVendidoPorId(int id, ProductoVendidoDTO productoVendidoDTO)
        {
            ProductoVendido? productoVendido = this.context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();

            if (productoVendido is not null)
            {
                productoVendido.IdProducto = productoVendidoDTO.IdProducto;
                productoVendido.Stock = productoVendidoDTO.Stock;
                productoVendido.Id = productoVendidoDTO.Id;
                productoVendido.IdVenta = productoVendidoDTO.IdVenta;

                this.context.ProductoVendidos.Update(productoVendido);
                this.context.SaveChanges();
                return true;
            }


            return false;
        }
    }
}
