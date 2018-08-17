using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.Models.PaginaModelo.Personas;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Mappers.Personas
{
    internal class PersonaModelToPersona : IMapper<PersonaModel, Persona>
    {
        public void Map(PersonaModel src, Persona dest)
        {
            dest.id = src.Id;
            dest.nombre = src.Nombre;
            dest.apellido = src.Apellido;
            dest.correo = src.Correo;
            dest.direccion = src.Direccion;
            dest.pais = (byte)src.Pais;
            dest.telefono = src.Telefono;
        }

        public Persona MapNew(PersonaModel src)
        {
            return new Persona
            {
                id = src.Id,
                nombre = src.Nombre,
                apellido = src.Apellido,
                correo = src.Correo,
                direccion = src.Direccion,
                pais = (byte)src.Pais,
                telefono = src.Telefono,
            };
        }
    }
}
