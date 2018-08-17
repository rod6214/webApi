using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.EntityFramework.PaginaModelo.Mappers.Perfiles;
using Bpba.Models.PaginaModelo.Perfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class PerfilRetriever : ICrud<PerfilModel>
    {
        PerfilToPerfilModel _perfilMMap = new PerfilToPerfilModel();
        PerfilModelToPerfil _perfilMap = new PerfilModelToPerfil();

        public void Delete(int id)
        {
            using (var db = new paginaEntities())
            {
                var perfil = db?.Perfiles?.Where(x => x.id == id)?.First();
                if(perfil != null)
                {
                    db.Perfiles.Remove(perfil);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<PerfilModel> GetAll()
        {
            using (var db = new paginaEntities())
            {
                if (db?.Perfiles != null)
                    foreach (var perfil in db.Perfiles)
                        yield return _perfilMMap.MapNew(perfil);
            }
        }

        public PerfilModel GetById(int id)
        {
            using (var db = new paginaEntities())
            {
                var perfil = db.Perfiles.Where(x => x.id == id).FirstOrDefault();
                return _perfilMMap.MapNew(perfil);
            }
        }

        public PerfilModel Register(PerfilModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var perfilM = db?.Perfiles?.Add(_perfilMap.MapNew(src));
                    db?.SaveChanges();
                    return _perfilMMap.MapNew(perfilM);
                }
                return null;
            }
        }

        public void Update(PerfilModel src)
        {
            using (var db = new paginaEntities())
            {
                
                if(src != null)
                {
                    var perfil = db?.Perfiles?.Where(x => x.id == src.Id)?.First();
                    if(perfil != null)
                    {
                        _perfilMap.Map(src, perfil);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
