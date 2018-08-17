using Util.Enums;

namespace Bpba.Models.PaginaModelo.Perfiles
{
    public class PerfilModel
    {
        public int Id { get; set; }
        public AccountAccess Acceso { get; set; }
        public string Descripcion { get; set; }
        public int Usuario_id { get; set; }
    }
}
