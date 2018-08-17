using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webPractice1.Models;

namespace webPractice1.Controllers
{
    public class UsuariosController : ApiController
    {
        private DBTestEntities db = new DBTestEntities();

        [HttpGet]
        public IEnumerable<AUsuario> GetUsers()
        {
            return db.AUsuario;
        }

        [HttpPost]
        public void RegisterUser(AUsuario usr)
        {
            if(usr != null)
            {
                db.AUsuario.Add(usr);
                db.SaveChanges();
            }
        }
    }
}
