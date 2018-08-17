using Bpba.Models.PaginaModelo.Inaventarios;
using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Util.Interfaces;
using Util.Enums;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Inventarios
{
    internal class InventarioToInventarioModel : IMapper<Inventario, InventarioModel>
    {
        public void Map(Inventario src, InventarioModel dest)
        {
            dest.Id = src.id;
            dest.Disponible = src.disponible;
            dest.Pais = (Country)src.pais;
            dest.Precio = src.precio;
            dest.Usuario_id = src.Usuario_id;
            dest.Articulo_id = src.Articulo_id;
            dest.Lugar = (City)src.ciudad;
        }

        public InventarioModel MapNew(Inventario src)
        {
            return new InventarioModel
            {
                Id = src.id,
                Disponible = src.disponible,
                Pais = (Country)src.pais,
                Precio = src.precio,
                Usuario_id = src.Usuario_id,
                Articulo_id = src.Articulo_id,
                Lugar = (City)src.ciudad,
            };
        }
    }
}
