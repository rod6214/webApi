using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Ventas;
using Util.Enums;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Ventas
{
    internal class VentaToVentaModel : IMapper<Venta, VentaModel>
    {
        public void Map(Venta src, VentaModel dest)
        {
            dest.Id = src.id;
            dest.Fecha = src.fecha;
            dest.Inventario_id = src.Inventario_id;
            dest.Comprador_id = src.comprador_id;
            dest.Status = (StatusVentas)src.status;
        }

        public VentaModel MapNew(Venta src)
        {
            return new VentaModel
            {
                Id = src.id,
                Fecha = src.fecha,
                Inventario_id = src.Inventario_id,
                Comprador_id = src.comprador_id,
                Status = (StatusVentas)src.status
            };
        }
    }
}
