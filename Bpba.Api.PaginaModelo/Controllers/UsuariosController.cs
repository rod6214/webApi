using Bpba.Api.PaginaModelo.Security;
using Bpba.Models.PaginaModelo.Personas;
using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Services.PaginaModelo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bpba.Api.PaginaModelo.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        [SecurityAccess(Users = "rod6214",Roles = "pupu")]
        [Route("persona/modificar")]
        [HttpGet]
        public void ModificarDatosPersonales(PersonaModel persona)
        {
            
            Console.WriteLine();
        }
        [Route("articulo/registrar")]
        [HttpPost]
        public void RegistrarArticulo() { }
        [Route("articulo/ventas")]
        [HttpGet]
        public void VerVentas() { }
        [Route("articulo/compras")]
        [HttpGet]
        public void VerCompras() { }
        [Route("articulo/comprar")]
        [HttpPut]
        public void ComprarArticulo() { }
        [Route("articulo/vender")]
        [HttpPut]
        public void VenderArticulo() { }
        [Route("articulo/borrar")]
        [HttpDelete]
        public void BorrarArticulo() { }
    }
}
