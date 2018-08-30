using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.EntityFramework.PaginaModelo.Mappers.Sesiones;
using Bpba.Models.PaginaModelo.Sesiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Converters;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class SesionRetriever : ICrud<SesionModel>
    {
        SesionToSesionModel _sesMMap = new SesionToSesionModel();
        SesionModelToSesion _sesMap = new SesionModelToSesion();
        Converter _converter = new Converter();
        public void Delete(int id)
        {
            using (var db = new paginaEntities())
            {
                var sesion = db?.Sesiones?.Where(x => x.id == id)?.First();
                if(sesion != null)
                {
                    db.Sesiones.Remove(sesion);
                    db.SaveChanges();
                }
            }
        }
        public void Delete(string sesionName)
        {
            bool status;
            int id = _converter.GetInteger(sesionName, out status);
            if (status)
                Delete(id);
        }
        public IEnumerable<SesionModel> GetAll()
        {
            using (var db = new paginaEntities())
            {
                if(db?.Sesiones != null)
                {
                    foreach (var sesion in db.Sesiones)
                        yield return _sesMMap.MapNew(sesion);
                }
            }
        }
        public SesionModel GetByUsuarioId(int usuarioId)
        {
            using (var db = new paginaEntities())
            {
                var sesion = db.Sesiones?.Where(x => x.Usuario_id == usuarioId)?.FirstOrDefault();
                if (sesion != null)
                    return _sesMMap.MapNew(sesion);
                return null;
            }
        }
        public SesionModel GetById(int id)
        {
            
            using (var db = new paginaEntities())
            {
                var sesion = db.Sesiones.Where(x => x.id == id).FirstOrDefault();
                return _sesMMap.MapNew(sesion);
            }
        }
        public SesionModel GetByKeyPair(Tuple<string, string> keyValue)
        {
            using (var db = new paginaEntities())
            {
                var sesion = db.Sesiones?.
                    Where(x => x.key.Equals(keyValue.Item1) && x.value.Equals(keyValue.Item2))?.FirstOrDefault();
                if (sesion != null)
                    return _sesMMap.MapNew(sesion);
                return null;
            }
        }
        public SesionModel GetById(string sesionName)
        {
            bool status;
            int id = _converter.GetInteger(sesionName, out status);
            if (status)
                return GetById(id);
            return null;
        }
        public SesionModel Register(SesionModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var sesionM = db?.Sesiones?.Add(_sesMap.MapNew(src));
                    db?.SaveChanges();
                    return _sesMMap.MapNew(sesionM);
                }
                return null;
            }
        }
        public void Update(SesionModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var sesion = db?.Sesiones?.Where(x => x.id == src.Id)?.First();
                    if(sesion != null)
                    {
                        _sesMap.Map(src, sesion);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
