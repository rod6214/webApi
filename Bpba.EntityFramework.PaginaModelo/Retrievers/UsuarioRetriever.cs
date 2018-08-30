using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.EntityFramework.PaginaModelo.Mappers.Usuarios;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Models.PaginaModelo.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class UsuarioRetriever : ICrud<UsuarioModel>
    {
        private UsuarioToUsuarioModel _usrMMap = new UsuarioToUsuarioModel();
        private UsuarioModelToUsuario _usrMap = new UsuarioModelToUsuario();

        public IEnumerable<UsuarioModel> GetAll()
        {
            using (var db = new paginaEntities())
            {
                if (db?.Usuarios != null)
                    foreach (var usuario in db?.Usuarios)
                        yield return _usrMMap.MapNew(usuario);
            }
        }
        public UsuarioModel GetUsuarioBySesion(SesionModel sesionM)
        {
            using (var db = new paginaEntities())
            {
                var sesion = db.Usuarios?.Where(x => x.id == sesionM.Usuario_id)?.FirstOrDefault();
                if (sesion != null)
                    return _usrMMap.MapNew(sesion);
                return null;
            }
        }
        public UsuarioModel GetById(int id)
        {
            using (var db = new paginaEntities())
            {
                var usuario = db.Usuarios.Where(x => x.id == id).FirstOrDefault();
                return _usrMMap.MapNew(usuario);
            }
        }

        public UsuarioModel Register(UsuarioModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var usuarioM = db?.Usuarios?.Add(_usrMap.MapNew(src));
                    db?.SaveChanges();
                    return _usrMMap.MapNew(usuarioM);
                }
                return null;
            }
        }

        public void Update(UsuarioModel src)
        {
            using (var db = new paginaEntities())
            {
                if (src != null)
                {
                    var usuario = db?.Usuarios?.Where(x => x.id == src.Id)?.First();
                    if(usuario != null)
                    {
                        _usrMap.Map(src, usuario);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new paginaEntities())
            {
                var usuario = db?.Usuarios?.Where(x => x.id == id)?.First();
                if(usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                }
            }
        }
    }
}
