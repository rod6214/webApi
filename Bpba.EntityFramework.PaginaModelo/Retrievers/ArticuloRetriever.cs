using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.EntityFramework.PaginaModelo.Mappers.Articulos;
using Bpba.Models.PaginaModelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class ArticuloRetriever : ICrud<ArticuloModel>
    {
        private ArticuloToArticuloModel _artMMap = new ArticuloToArticuloModel();
        private ArticuloModelToArticulo _artMap = new ArticuloModelToArticulo();
        public void Delete(int id)
        {
            using (var db = new paginaEntities())
            {
                var articulo = db?.Articulos?.Where(x => x.id == id)?.First();
                if (articulo != null)
                {
                    db.Articulos.Remove(articulo);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<ArticuloModel> GetAll()
        {
            using (var db = new paginaEntities())
            {
                if (db?.Articulos != null)
                    foreach (var articulo in db.Articulos)
                        yield return _artMMap.MapNew(articulo);
            }
        }

        public ArticuloModel GetById(int id)
        {
            using (var db = new paginaEntities())
            {
                var articulo = db.Articulos.Where(x => x.id == id).FirstOrDefault();
                return _artMMap.MapNew(articulo);
            }
        }

        public ArticuloModel Register(ArticuloModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var articuloM = db?.Articulos?.Add(_artMap.MapNew(src));
                    db?.SaveChanges();
                    return _artMMap.MapNew(articuloM);
                }
                return null;
            }
        }

        public void Update(ArticuloModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var articulo = db?.Articulos?.Where(x => x.id == src.Id)?.First();
                    if (articulo != null)
                    {
                        _artMap.Map(src, articulo);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
