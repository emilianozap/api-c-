using app.DTOs;
using app.Services;
using app.models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoService productoVendidoService;
        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.productoVendidoService = productoVendidoService;


        }


        [HttpGet("listar")]
        public List<ProductoVendido> ObtenerListadoDeProductosVendidos()
        {
            return this.productoVendidoService.ObtenerTodosLosProductosVendidos();
        }




        [HttpPost]
        public IActionResult AgregarUnNuevoProductoVendido([FromBody] ProductoVendidoDTO productoVendido)
        {

            if (this.productoVendidoService.AgregarUnProductoVendido(productoVendido))
            {

                return base.Ok(new { mensaje = "Producto vendido agregado", productoVendido });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego un producto vendido" });
            }
        }




        [HttpDelete("{id}")]
        public IActionResult BorrarProductoVendido(int id)
        {
            if (id > 0)
            {
                if (this.productoVendidoService.BorrarProductoVendidoPorId(id))
                {
                    return base.Ok(new { mensaje = "Producto vendido borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el producto vendido" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProductoVendidoPorId(int id, ProductoVendidoDTO productoVendidoDTO)
        {
            if (id > 0)
            {
                if (this.productoVendidoService.ActualizarProductoVendidoPorId(id, productoVendidoDTO))
                {
                    return base.Ok(new { mensaje = "Producto vendido Actualizado", status = 200, productoVendidoDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el producto vendido" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }
    }

}    
