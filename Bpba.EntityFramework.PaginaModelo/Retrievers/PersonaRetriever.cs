using Bpba.EntityFramework.PaginaModelo.EntityModel;
using Bpba.EntityFramework.PaginaModelo.Mappers.Personas;
using Bpba.Models.PaginaModelo.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;

namespace Bpba.EntityFramework.PaginaModelo.Retrievers
{
    public class PersonaRetriever : ICrud<PersonaModel>
    {
        private PersonaToPersonaModel _perMMap = new PersonaToPersonaModel();
        private PersonaModelToPersona _perMap = new PersonaModelToPersona();
        public void Delete(int id)
        {
            using (var db = new paginaEntities())
            {
                var persona = db?.Personas?.Where(x => x.id == id)?.First();
                if(persona != null)
                {
                    db.Personas.Remove(persona);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<PersonaModel> GetAll()
        {
            using (var db = new paginaEntities())
            {
                if (db?.Personas != null)
                    foreach (var persona in db.Personas)
                        yield return _perMMap.MapNew(persona);
            }
        }

        public PersonaModel GetById(int id)
        {
            using (var db = new paginaEntities())
            {
                var persona = db.Personas.Where(x => x.id == id).FirstOrDefault();
                return _perMMap.MapNew(persona);
            }
        }

        public PersonaModel Register(PersonaModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var personaM = db?.Personas?.Add(_perMap.MapNew(src));
                    db?.SaveChanges();
                    return _perMMap.MapNew(personaM);
                }
                return null;
            }
        }

        public void Update(PersonaModel src)
        {
            using (var db = new paginaEntities())
            {
                if(src != null)
                {
                    var persona = db?.Personas?.Where(x => x.id == src.Id)?.First();
                    if(persona != null)
                    {
                        _perMap.Map(src, persona);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
