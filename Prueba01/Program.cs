using Bpba.EntityFramework.PaginaModelo.Retrievers;
using Bpba.Models.PaginaModelo.Perfiles;
using Bpba.Models.PaginaModelo.Personas;
using Bpba.Models.PaginaModelo.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Util.Converters;
//using Util.Enums;

namespace Prueba01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Converter converter = new Converter();
            //string saludo = "Hola Mundo!!!djcndjcndjcndjcndjcnjdcnjdncjdncjdncjdncjdncjndjcndjcndjcndj amigo mio";
            //string pass = "remosino";
            //string encrypted = converter.Encrypt256(saludo, pass);
            //string result = converter.Decrypt256(encrypted, pass);

            //string valor = "mk";
            //int entero;
            //bool isEnetero = int.TryParse(valor, out entero);
            //TimeSpan time = new TimeSpan(365, 0, 0, 0, 0);
            //DateTime duracion = DateTime.Now;
            //DateTime dur2 = duracion + time;
            //RootRegister();
            //AccountAccess access = AccountAccess.ADMIN | AccountAccess.USER;   
        }


        //public static void RootRegister()
        //{
        //    PersonaRetriever perRet = new PersonaRetriever();
        //    UsuarioRetriever usrRet = new UsuarioRetriever();
        //    PerfilRetriever perfRet = new PerfilRetriever();
        //    Converter converter = new Converter();
        //    if(perRet.GetAll().Count() <= 0)
        //    {
        //        perRet.Register(new PersonaModel
        //        {
        //            Id = 0,
        //            Nombre = "Nelson",
        //            Apellido = "Amador",
        //            Correo = "rod6232@hotmail.com",
        //            Direccion = "",
        //            Pais = Country.VENEZUELA,
        //            Telefono = ""
        //        });
        //        PersonaModel root = perRet.GetById(1);
        //        usrRet.Register(new UsuarioModel
        //        {
        //            Id = 0,
        //            Lastlogin = DateTime.Now,
        //            Nombre = "admin",
        //            Pass = converter.Encrypt256("admin"),
        //            Persona_id = root.Id
        //        });
        //        UsuarioModel rootUser = usrRet.GetById(1);
        //        perfRet.Register(new PerfilModel
        //        {
        //            Id = 0,
        //            Acceso = AccountAccess.ROOT,
        //            Descripcion = "Cuenta Maestra",
        //            Usuario_id = rootUser.Id
        //        });
        //    }
        //}
    }
}
