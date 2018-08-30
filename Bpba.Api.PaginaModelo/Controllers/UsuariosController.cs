using Bpba.Api.PaginaModelo.Security;
using Bpba.Models.PaginaModelo.Personas;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Models.PaginaModelo.Usuarios;
using Bpba.Services.PaginaModelo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Util.Enums;
using Util.Converters;
using System.Configuration;

namespace Bpba.Api.PaginaModelo.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        private UsuariosVal _usuarios = new UsuariosVal();
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("persona/modificar")]
        [HttpPost]
        public void ModificarDatosPersonales(PersonaModel persona)
        {
            var keyToken = ConfigurationManager.AppSettings["CookieName"];
            var valueToken = new Converter().GetHeaderKeyPair(ActionContext, keyToken);
            SesionVal sesion = new SesionVal(new CookieModel
            {
                Key = keyToken,
                Value = valueToken
            });
            UsuarioModel usuario = sesion.GetUsuario();
            //_usuarios.SetDatosPersonales(usuario.Id, persona);
        }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("articulo/registrar")]
        [HttpPost]
        public void RegistrarArticulo() { }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("articulo/ventas")]
        [HttpGet]
        public void VerVentas() { }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("articulo/compras")]
        [HttpGet]
        public void VerCompras() { }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("articulo/comprar")]
        [HttpPut]
        public void ComprarArticulo() { }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("articulo/vender")]
        [HttpPut]
        public void VenderArticulo() { }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("articulo/borrar")]
        [HttpDelete]
        public void BorrarArticulo() { }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("persona/registrar")]
        [HttpPost]
        public void RegistrarUsuario(UsuarioModel usuario)
        {
        }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("persona/registrar")]
        [HttpPost]
        public void ModificarUsuario(UsuarioModel usuario)
        {
        }
        [SecurityAccess(Roles = AccountAccess.ADMIN | AccountAccess.ROOT)]
        [Route("usuario/eliminar/{usuarioId}")]
        [HttpPost]
        public void EliminarUsuario(int usuarioId)
        {
        }
        [SecurityAccess(Roles = AccountAccess.USER)]
        [Route("persona/modificar/{usuarioId}")]
        [HttpPost]
        public void ModificarPersona(PersonaModel persona)
        {
        }
    }
}
