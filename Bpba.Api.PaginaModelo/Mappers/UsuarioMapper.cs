using Bpba.Models.PaginaModelo.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.Interfaces;

namespace Bpba.Api.PaginaModelo.Mappers
{
    public class UsuarioMapper : IMapper<RegistroUsuarioModel, UsuarioModel>
    {
        public void Map(RegistroUsuarioModel src, UsuarioModel dest)
        {
            dest.Id = 0;
            dest.Nombre = src.Nombre;
            dest.Pass = src.Pass;
        }

        public UsuarioModel MapNew(RegistroUsuarioModel src)
        {
            return new UsuarioModel
            {
                Id = 0,
                Nombre = src.Nombre,
                Pass = src.Pass
            };
        }
    }
}