using Bpba.Models.PaginaModelo.Inaventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.Enums;

namespace Bpba.Models.PaginaModelo.Ventas
{
    public class VentaModel : ICloneable<VentaModel>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Inventario_id { get; set; }
        public int Comprador_id { get; set; }
        public StatusVentas Status { get; set; }
        public VentaModel Clone()
        {
            return new VentaModel
            {
                Id = Id,
                Comprador_id = Comprador_id,
                Fecha = Fecha,
                Inventario_id = Inventario_id,
                Status = Status
            };
        }
    }
}
