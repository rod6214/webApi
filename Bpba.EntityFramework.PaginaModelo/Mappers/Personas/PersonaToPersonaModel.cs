using Bpba.Models.PaginaModelo.Personas;
using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Util.Interfaces;
using Util.Enums;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Personas
{
    internal class PersonaToPersonaModel : IMapper<Persona, PersonaModel>
    {
        public void Map(Persona src, PersonaModel dest)
        {
            dest.Id = src.id;
            dest.Nombre = src.nombre;
            dest.Apellido = src.apellido;
            dest.Correo = src.correo;
            dest.Direccion = src.direccion;
            dest.Pais = (Country)src.pais;
        }

        public PersonaModel MapNew(Persona src)
        {
            return new PersonaModel
            {
                Id = src.id,
                Nombre = src.nombre,
                Apellido = src.apellido,
                Correo = src.correo,
                Direccion = src.correo,
                Pais = (Country)src.pais,
                Telefono = src.telefono,
            };
        }
    }
}
