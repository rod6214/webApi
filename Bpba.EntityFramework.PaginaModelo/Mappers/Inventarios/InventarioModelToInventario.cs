using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Inaventarios;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Inventarios
{
    internal class InventarioModelToInventario : IMapper<InventarioModel, Inventario>
    {
        public void Map(InventarioModel src, Inventario dest)
        {
            dest.id = src.Id;
            dest.pais = (byte)src.Pais;
            dest.precio = src.Precio;
            dest.Usuario_id = src.Usuario_id;
            dest.disponible = src.Disponible;
            dest.ciudad = (int)src.Lugar;
            dest.Articulo_id = src.Articulo_id;
        }

        public Inventario MapNew(InventarioModel src)
        {
            return new Inventario
            {
                id = src.Id,
                pais = (byte)src.Pais,
                Articulo_id = src.Articulo_id,
                ciudad = (int)src.Lugar,
                disponible = src.Disponible,
                precio = src.Precio,
                Usuario_id = src.Usuario_id
            };
        }
    }
}
