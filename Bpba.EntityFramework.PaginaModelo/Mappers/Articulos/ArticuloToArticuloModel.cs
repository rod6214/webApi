using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Articulos;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Articulos
{
    internal class ArticuloToArticuloModel : IMapper<Articulo, ArticuloModel>
    {
        public void Map(Articulo src, ArticuloModel dest)
        {
            dest.Descripcion = src.descripcion;
            dest.Id = src.id;
            dest.Nombre = src.nombre;
        }

        public ArticuloModel MapNew(Articulo src)
        {
            return new ArticuloModel
            {
                Descripcion = src.descripcion,
                Id = src.id,
                Nombre = src.nombre,
            };
        }
    }
}
