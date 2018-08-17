using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Sesiones;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Sesiones
{
    internal class SesionToSesionModel : IMapper<Sesion, SesionModel>
    {
        public void Map(Sesion src, SesionModel dest)
        {
            dest.Id = src.id;
            dest.Key = src.key;
            dest.Value = src.value;
            dest.Usuario_id = src.Usuario_id;
            dest.Isonline = src.isonline;
            dest.TiempoInicial = src.initTime;
            dest.Duracion = src.duracion;
        }

        public SesionModel MapNew(Sesion src)
        {
            return new SesionModel
            {
                Id = src.id,
                Key = src.key,
                Value = src.value,
                Usuario_id = src.Usuario_id,
                Isonline = src.isonline,
                Duracion = src.duracion,
                TiempoInicial = src.initTime
            };
        }
    }
}
