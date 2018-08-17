using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Usuarios;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Usuarios
{
    internal class UsuarioModelToUsuario : IMapper<UsuarioModel, Usuario>
    {
        public void Map(UsuarioModel src, Usuario dest)
        {
            dest.id = src.Id;
            dest.nombre = src.Nombre;
            dest.lastlogin = src.Lastlogin;
            dest.pass = src.Pass;
            dest.Persona_id = src.Persona_id;
        }

        public Usuario MapNew(UsuarioModel src)
        {
            return new Usuario
            {
                id = src.Id,
                nombre = src.Nombre,
                pass = src.Pass,
                lastlogin = src.Lastlogin,
                Persona_id = src.Persona_id,
            };
        }
    }
}
