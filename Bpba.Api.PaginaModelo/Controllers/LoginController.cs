using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Models.PaginaModelo.Usuarios;
using Bpba.Services.PaginaModelo.Validation;
using System;
using System.Web.Http;

namespace Bpba.Api.PaginaModelo.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {

        [Route("login/token")]
        [HttpPost]
        public CookieModel Login(UsuarioModel usuario)
        {
            LoginVal login = new LoginVal(usuario);
            SesionVal sesion = null;
            SesionVal.CleanSesiones();
            if (login.IsValid)
                sesion = SesionVal.CreateSesion(login.ValidUser, new TimeSpan(0,45,0));
            return sesion?.Cookie;
        }
    }
}
