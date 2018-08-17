using Util.Enums;

namespace Bpba.Models.PaginaModelo.Personas
{
    public class PersonaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Country Pais { get; set; }
        public string Direccion { get; set; }
    }
}
