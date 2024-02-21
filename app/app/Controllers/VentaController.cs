using app.DTOs;
using app.Services;
using app.models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaService ventaService;
        public VentaController(VentaService ventaService)
        {
            this.ventaService = ventaService;


        }





        [HttpGet("listar")]
        public List<Ventum> ObtenerListadoDeVentas()
        {
            return this.ventaService.ObtenerTodosLasVentas();
        }




        [HttpPost]
        public IActionResult AgregarUnaNuevaVenta([FromBody] VentaDTO venta)
        {

            if (this.ventaService.AgregarVenta(venta))
            {

                return base.Ok(new { mensaje = "venta agregada", venta});
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego una venta" });
            }
        }




        [HttpDelete("{id}")]
        public IActionResult BorrarVenta(int id)
        {
            if (id > 0)
            {
                if (this.ventaService.BorrarVentaPorId(id))
                {
                    return base.Ok(new { mensaje = "venta borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar la venta" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarVentaPorId(int id, VentaDTO ventaDTO)
        {
            if (id > 0)
            {
                if (this.ventaService.ActualizarVentaPorId(id, ventaDTO))
                {
                    return base.Ok(new { mensaje = "venta Actualizado", status = 200, ventaDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el venta" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }
    }

}    
