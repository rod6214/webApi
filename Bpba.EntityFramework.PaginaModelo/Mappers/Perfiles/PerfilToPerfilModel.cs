using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Perfiles;
using Util.Enums;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Perfiles
{
    internal class PerfilToPerfilModel : IMapper<Perfil, PerfilModel>
    {
        public void Map(Perfil src, PerfilModel dest)
        {
            dest.Id = src.id;
            dest.Descripcion = src.descripcion;
            dest.Usuario_id = src.Usuario_id;
            dest.Acceso = (AccountAccess)src.acceso;
        }

        public PerfilModel MapNew(Perfil src)
        {
            return new PerfilModel
            {
                Id = src.id,
                Acceso = (AccountAccess)src.acceso,
                Descripcion = src.descripcion,
                Usuario_id = src.Usuario_id
            };
        }
    }
}
