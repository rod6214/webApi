using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Perfiles;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Models.PaginaModelo.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace Bpba.Services.PaginaModelo.Validation
{
    internal class Permisos
    {
        private UsuarioModel _usuario;
        private PerfilRetriever _perRet = new PerfilRetriever();
        private SesionVal _sesion;
        
        public Permisos(CookieModel cookie)
        {
            _sesion = new SesionVal(cookie);
            _usuario = _sesion.GetUsuario();
        }

        public PerfilModel GetPerfil()
        {
            //var perfil = _usuario?.Perfiles?.Where(x => x.Usuario_id == _usuario.Id).First();
            List<PerfilModel> lstPerfiles = new List<PerfilModel>();
            foreach (var pperfil in _perRet.GetAll())
                lstPerfiles.Add(pperfil);
            var perfil = lstPerfiles.Where(x => x.Usuario_id == _usuario.Id).First();
            if (perfil != null)
                return perfil;
            return null;
        }

        public bool IsValidAll(AccountAccess access)
        {

            if (_usuario != null)
            {
                if (_sesion.IsValidSesion)
                {
                    PerfilModel perfil = GetPerfil();
                    if (perfil != null)
                        if (perfil.Acceso == access)
                            return true;
                }
            }
            return false;
        }
    }
}
