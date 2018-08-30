using Bpba.Models.PaginaModelo.Sesiones;
using Bpba.Services.PaginaModelo.Security;
using Bpba.Services.PaginaModelo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Util.Enums;

namespace Bpba.Api.PaginaModelo.Security
{
    public class SecurityAccessAttribute : AuthorizeAttribute
    {
        public new AccountAccess Roles { get; set; }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string tokenName = SesionVal.SESION_ALIAS2;
            var value = actionContext.Request.Headers.Where(x => x.Key.Equals(tokenName))
                .FirstOrDefault().Value.FirstOrDefault();
            SecurityToken security = new SecurityToken();
            return security.IsAuthorized(new CookieModel
            {
                Key = tokenName,
                Value = value
            }, Roles);
        }
    }
}