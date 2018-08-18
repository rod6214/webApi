using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Models.PaginaModelo.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.Converters;

namespace Bpba.Services.PaginaModelo.Validation
{
    public class SesionVal
    {
        private Converter _converter = new Converter(); 
        private CookieModel _cookie;
        private SesionRetriever _sesRet = new SesionRetriever();
        private UsuarioRetriever _usrRet = new UsuarioRetriever();
        private SesionModel _sesion;
        private int _sesionCount;
        public const string SESION_ALIAS = "user";
        public const string SESION_ALIAS2 = "Token";
        public int SesionCount => _sesionCount;
        public bool IsValidSesion => ValidateSesion();
        public TimeSpan Duration => _sesion.Duracion;
        public CookieModel Cookie => _cookie;
        public SesionVal(CookieModel cookie)
        {
            _sesionCount = 0;
            foreach (var val in _sesRet.GetAll())
                _sesionCount++;
            _cookie = cookie;
            _sesion = _sesRet.GetById(_cookie.Key);
        }
        public static SesionVal CreateSesion(UsuarioModel usuario, TimeSpan duracion)
        {
            Random rnd = new Random();
            SesionRetriever sesRet = new SesionRetriever();
            List<SesionModel> lstSesiones = new List<SesionModel>();
            foreach (var psesion in sesRet.GetAll())
                lstSesiones.Add(psesion);
            var sesionCount = lstSesiones.Count();
            var valueCalculated = new Converter().
                Encrypt256(usuario.Nombre + usuario.Id + (rnd.Next(13, 65535)).ToString());
            SesionModel sesion = new SesionModel
            {
                Key = "",
                Value = valueCalculated,
                TiempoInicial = DateTime.Now,
                Isonline = true,
                Id = 0,
                Usuario_id = usuario.Id,
                Duracion = duracion
            };
            sesion = sesRet.Register(sesion);
            sesion.Key = SESION_ALIAS2;
            //sesion.Key = SESION_ALIAS + (sesion.Id).ToString();
            sesRet.Update(sesion);
            CookieModel cookie = new CookieModel
            {
                Key = sesion.Key,
                Value = sesion.Value
            };
            return new SesionVal(cookie);
        }
        public void CloseSesion()
        {
            if (IsValidSesion)
                _sesRet.Delete(_sesion.Id);
        }
        public UsuarioModel GetUsuario()
        {
            if (IsValidSesion)
                return _usrRet.GetById(_sesion.Usuario_id);
            return null;
        }
        public static void CleanSesiones()
        {
            SesionRetriever sesRet = new SesionRetriever();
            List<SesionModel> lstSesiones = new List<SesionModel>();
            foreach (var sesion in sesRet?.GetAll())
                lstSesiones.Add(sesion);
            var sesionesTerminadas = lstSesiones?.Where(x => x.TiempoInicial + x.Duracion < DateTime.Now);
            if (sesionesTerminadas != null)
                foreach (var sesionTerminada in sesionesTerminadas)
                    sesRet.Delete(sesionTerminada.Id);
        }
        private bool ValidateSesion()
        {
            if (_cookie == null)
                return false;
            if(_sesion != null)
                if (_sesion.Value.Equals(_cookie.Value))
                    return true;
            return false;
        }
    }
}
