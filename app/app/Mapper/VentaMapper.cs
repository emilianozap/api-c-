﻿using app.DTOs;
using app.models;

namespace app.Mapper
{
    public static class VentaMapper
    {
        public static Ventum MapearAVenta(VentaDTO dto)
        {
            Ventum venta = new Ventum();
            venta.Id = dto.Id;
            venta.Comentarios = dto.Comentarios;
            venta.IdUsuario = dto.IdUsuario;
        

            return venta;
        }

        public static VentaDTO MapearADTO(Ventum venta)
        {
            VentaDTO dto = new VentaDTO();

            dto.Id = venta.Id;
            dto.Comentarios = venta.Comentarios;
            dto.IdUsuario = venta.IdUsuario;

            return dto;
        }
    }
}
