using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Sesiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bpba.Services.PaginaModelo.Security
{
    public class SecurityToken
    {
        private CookieRetriever _cookRet = new CookieRetriever();
        public bool IsAuthorized(CookieModel cookie)
        {
            List<CookieModel> cookies = new List<CookieModel>();
            foreach (var cook in _cookRet.GetAll())
                cookies.Add(cook);
            return cookies.Any(x => x.Value.Equals(cookie.Value) && x.Key.Equals(cookie.Key));
        }
    }
}
