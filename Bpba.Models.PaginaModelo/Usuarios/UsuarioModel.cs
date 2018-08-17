using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;
using Bpba.Models.PaginaModelo.Personas;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Models.PaginaModelo.Perfiles;
using Bpba.Models.PaginaModelo.Inaventarios;

namespace Bpba.Models.PaginaModelo.Usuarios
{
    public class UsuarioModel
    {
        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public int Persona_id { get; set; }
        public DateTime Lastlogin { get; set; }
        #endregion
    }
}
