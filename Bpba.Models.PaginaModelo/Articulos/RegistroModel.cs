using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace Bpba.Models.PaginaModelo.Articulos
{
    public class RegistroModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public City Lugar { get; set; }
        public Country Pais { get; set; }
        public bool Disponible { get; set; }
    }
}
