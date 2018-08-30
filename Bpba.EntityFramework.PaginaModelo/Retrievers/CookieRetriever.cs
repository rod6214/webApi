using Bpba.Models.PaginaModelo.Sesiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class CookieRetriever
    {
        private SesionRetriever _sessRet = new SesionRetriever();
        public CookieModel GetCookieByUsuarioId(int usuarioId)
        {
            var sesion = _sessRet.GetAll().Where(x => x.Usuario_id == usuarioId)
                .FirstOrDefault();
            return new CookieModel
            {
                Key = sesion.Key,
                Value = sesion.Value
            };
        }

        public IEnumerable<CookieModel> GetAll()
        {
            var sesiones = _sessRet.GetAll();
            foreach (var sesion in sesiones)
                yield return new CookieModel
                {
                    Key = sesion.Key,
                    Value = sesion.Value
                };
        }
    }
}
