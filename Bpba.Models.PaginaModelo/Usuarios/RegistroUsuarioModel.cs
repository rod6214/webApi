using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace Bpba.Models.PaginaModelo.Usuarios
{
    public class RegistroUsuarioModel
    {
        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Country Pais { get; set; }
        public string Direccion { get; set; }
        #endregion
    }
}
