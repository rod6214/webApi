using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Articulos;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Articulos
{
    internal class ArticuloModelToArticulo : IMapper<ArticuloModel, Articulo>
    {
        public void Map(ArticuloModel src, Articulo dest)
        {
            dest.id = src.Id;
            dest.nombre = src.Nombre;
            dest.descripcion = src.Descripcion;
        }

        public Articulo MapNew(ArticuloModel src)
        {
            return new Articulo
            {
                id = src.Id,
                nombre = src.Nombre,
                descripcion = src.Descripcion
            };
        }
    }
}
