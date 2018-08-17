using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Perfiles;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Perfiles
{
    internal class PerfilModelToPerfil : IMapper<PerfilModel, Perfil>
    {
        public void Map(PerfilModel src, Perfil dest)
        {
            dest.id = src.Id;
            dest.descripcion = src.Descripcion;
            dest.acceso = (byte)src.Acceso;
        }

        public Perfil MapNew(PerfilModel src)
        {
            return new Perfil
            {
                id = src.Id,
                acceso = (byte)src.Acceso,
                descripcion = src.Descripcion,
                Usuario_id = src.Usuario_id
            };
        }
    }
}
