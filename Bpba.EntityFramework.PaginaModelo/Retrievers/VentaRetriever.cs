using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.EntityFramework.PaginaModelo.Mappers.Ventas;
using Bpba.Models.PaginaModelo.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class VentaRetriever : ICrud<VentaModel>
    {
        private VentaModelToVenta _ventMap = new VentaModelToVenta();
        private VentaToVentaModel _ventMMap = new VentaToVentaModel();
        public void Delete(int id)
        {
            using (var db = new paginaEntities())
            {
                var venta = db?.Ventas?.Where(x => x.id == id)?.First();
                if (venta != null)
                {
                    db.Ventas.Remove(venta);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<VentaModel> GetAll()
        {
            using (var db = new paginaEntities())
            {
                if (db?.Ventas != null)
                    foreach (var venta in db.Ventas)
                        yield return _ventMMap.MapNew(venta);
            }
        }

        public VentaModel GetById(int id)
        {
            using (var db = new paginaEntities())
            {
                var venta = db.Ventas.Where(x => x.id == id).FirstOrDefault();
                return _ventMMap.MapNew(venta);
            }
        }

        public VentaModel Register(VentaModel src)
        {
            using (var db = new paginaEntities())
            {
                if (src != null)
                {
                    var ventaM = db?.Ventas?.Add(_ventMap.MapNew(src));
                    db?.SaveChanges();
                    return _ventMMap.MapNew(ventaM);
                }
                return null;
            }
        }

        public void Update(VentaModel src)
        {
            using (var db = new paginaEntities())
            {
                if (src != null)
                {
                    var venta = db?.Ventas?.Where(x => x.id == src.Id)?.First();
                    if (venta != null)
                    {
                        _ventMap.Map(src, venta);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
