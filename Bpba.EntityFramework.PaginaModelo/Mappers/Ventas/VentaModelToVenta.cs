using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Ventas;
using System.Collections.Generic;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Ventas
{
    internal class VentaModelToVenta : IMapper<VentaModel, Venta>
    {
        public void Map(VentaModel src, Venta dest)
        {
            dest.id = src.Id;
            dest.comprador_id = src.Comprador_id;
            dest.fecha = src.Fecha;
            dest.Inventario_id = src.Inventario_id;
            dest.status = (byte)src.Status;
        }

        public Venta MapNew(VentaModel src)
        {
            List<Venta> ventas = new List<Venta>();

            return new Venta
            {
                id = src.Id,
                comprador_id = src.Comprador_id,
                fecha = src.Fecha,
                Inventario_id = src.Inventario_id,
                status = (byte)src.Status
            };
        }
    }
}
