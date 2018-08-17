using Bpba.Models.PaginaModelo.Perfiles;
using Bpba.Models.PaginaModelo.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bpba.Models.PaginaModelo.Usuarios
{
    public class UsuarioRegisterModel
    {
        public PersonaModel Persona { get; set; }
        public UsuarioModel Usuario { get; set; }
        //public PerfilModel Perfil { get; set; }
    }
}
