using Bpba.Models.PaginaModelo.Personas;
using Bpba.Models.PaginaModelo.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.Interfaces;

namespace Bpba.Api.PaginaModelo.Mappers
{
    public class PersonaMapper : IMapper<RegistroUsuarioModel, PersonaModel>
    {
        public void Map(RegistroUsuarioModel src, PersonaModel dest)
        {
            dest.Nombre = src.NombrePersona;
            dest.Apellido = src.ApellidoPersona;
            dest.Correo = src.Correo;
            dest.Pais = src.Pais;
            dest.Telefono = src.Telefono;
            dest.Id = 0;
            dest.Direccion = src.Correo;
        }

        public PersonaModel MapNew(RegistroUsuarioModel src)
        {
            return new PersonaModel
            {
                Id = 0,
                Nombre = src.NombrePersona,
                Apellido = src.ApellidoPersona,
                Correo = src.Correo,
                Direccion = src.Direccion,
                Pais = src.Pais,
                Telefono = src.Telefono
            };
        }
    }
}