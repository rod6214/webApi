using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.EntityFramework.PaginaModelo.Mappers;
using Bpba.EntityFramework.PaginaModelo.Mappers.Inventarios;
using Bpba.Models.PaginaModelo.Inaventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class InventarioRetriever : ICrud<InventarioModel>
    {
        InventarioToInventarioModel _invMMap = new InventarioToInventarioModel();
        InventarioModelToInventario _invMap = new InventarioModelToInventario();
        public void Delete(int id)
        {
            using (var db = new paginaEntities())
            {
                var inventario = db?.Inventarios?.Where(x => x.id == id)?.First();
                if (inventario != null)
                {
                    db.Inventarios.Remove(inventario);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<InventarioModel> GetAll()
        {
            using (var db = new paginaEntities())
            {
                if (db?.Inventarios != null)
                    foreach (var inventario in db.Inventarios)
                        yield return _invMMap.MapNew(inventario);
            }
        }

        public InventarioModel GetById(int id)
        {
            using (var db = new paginaEntities())
            {
                var inventario = db.Inventarios.Where(x => x.id == id).FirstOrDefault();
                return _invMMap.MapNew(inventario);
            }
        }

        public InventarioModel Register(InventarioModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var inventarioM = db?.Inventarios?.Add(_invMap.MapNew(src));
                    db?.SaveChanges();
                    return _invMMap.MapNew(inventarioM);
                }
                return null;
            }
        }

        public void Update(InventarioModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var inventario = db?.Inventarios?.Where(x => x.id == src.Id)?.First();
                    if (inventario != null)
                    {
                        _invMap.Map(src, inventario);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
