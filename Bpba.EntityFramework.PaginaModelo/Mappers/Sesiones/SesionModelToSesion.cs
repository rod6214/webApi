using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Sesiones;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Sesiones
{
    internal class SesionModelToSesion : IMapper<SesionModel, Sesion>
    {
        public void Map(SesionModel src, Sesion dest)
        {
            dest.id = src.Id;
            dest.isonline = src.Isonline;
            dest.key = src.Key;
            dest.value = src.Value;
            dest.Usuario_id = src.Usuario_id;
            dest.duracion = src.Duracion;
            dest.initTime = src.TiempoInicial;
        }

        public Sesion MapNew(SesionModel src)
        {
            return new Sesion
            {
                id = src.Id,
                isonline = src.Isonline,
                key = src.Key,
                value = src.Value,
                Usuario_id = src.Usuario_id,
                initTime = src.TiempoInicial,
                duracion = src.Duracion
            };
        }
    }
}
