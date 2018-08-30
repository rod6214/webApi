using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Perfiles;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Services.PaginaModelo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace Bpba.Services.PaginaModelo.Security
{
    public class SecurityToken
    {
        private CookieRetriever _cookRet = new CookieRetriever();
        private SesionRetriever _sesRet = new SesionRetriever();
        private PerfilRetriever _perfilRet = new PerfilRetriever();
        protected bool IsAuthorized(CookieModel cookie)
        {
            List<CookieModel> cookies = new List<CookieModel>();
            SesionVal.CleanSesiones();
            foreach (var cook in _cookRet.GetAll())
                cookies.Add(cook);
            return cookies.Any(x => x.Value.Equals(cookie.Value) && x.Key.Equals(cookie.Key));
        }
        public bool IsAuthorized(CookieModel cookie, AccountAccess access, bool withAccess = true)
        {
            if(withAccess)
            {
                List<SesionModel> lstSesiones = new List<SesionModel>();
                List<PerfilModel> lstPerfiles = new List<PerfilModel>();
                foreach (var psesion in _sesRet.GetAll())
                    lstSesiones.Add(psesion);
                foreach (var pperfil in _perfilRet.GetAll())
                    lstPerfiles.Add(pperfil);
                var sesion = lstSesiones?.Where(x => x.Key.Equals(cookie.Key)
                    && x.Value.Equals(cookie.Value))?.FirstOrDefault();
                var perfil = lstPerfiles?
                    .Where(x => x.Usuario_id == sesion?.Usuario_id)?.FirstOrDefault();
                return IsAuthorized(cookie) && perfil?.Acceso >= access;
            }
            return IsAuthorized(cookie);
        }
    }
}
