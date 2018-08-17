using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Usuarios;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Usuarios
{
    internal class UsuarioToUsuarioModel : IMapper<Usuario, UsuarioModel>
    {
        public void Map(Usuario src, UsuarioModel dest)
        {
            dest.Id = src.id;
            dest.Nombre = src.nombre;
            dest.Persona_id = src.Persona_id;
            dest.Pass = src.pass;
            dest.Lastlogin = src.lastlogin;
        }

        public UsuarioModel MapNew(Usuario src)
        {
            return new UsuarioModel
            {
                Id = src.id,
                Nombre = src.nombre,
                Pass = src.pass,
                Lastlogin = src.lastlogin,
                Persona_id = src.Persona_id,
            };
        }
    }
}
