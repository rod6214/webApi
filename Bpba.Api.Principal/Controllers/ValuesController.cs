using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Util.Attributes;

namespace Bpba.Api.Principal.Controllers
{
    
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        [SecurityAccess(Roles = "administrador")]
        [Route("ver/personas")]
        [HttpGet]
        public void Ejemplo()
        {
            Console.WriteLine();
        }
    }
}
