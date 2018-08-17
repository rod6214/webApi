using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace Bpba.Models.PaginaModelo.Usuarios
{
    public class UsuarioResultModel
    {
        public string UserName { get; set; }
        public AccountAccess UserRole { get; set; }
    }
}
