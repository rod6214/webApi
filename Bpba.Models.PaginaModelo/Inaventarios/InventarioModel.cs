using Util.Enums;

namespace Bpba.Models.PaginaModelo.Inaventarios
{
    public class InventarioModel
    {
        public int Id { get; set; }
        public bool Disponible { get; set; }
        public decimal Precio { get; set; }
        public City Lugar { get; set; }
        public int Usuario_id { get; set; }
        public int Articulo_id { get; set; }
        public Country Pais { get; set; }
    }
}
