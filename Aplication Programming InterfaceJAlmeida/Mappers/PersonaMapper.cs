using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;
using AutoMapper;

namespace Aplication_Programming_InterfaceJAlmeida.Mappers
{
    public class PersonaMapper
    {
        public PersonaMapper()
        {

        }
        public static PersonaEntity GetPersona(Persona personadb)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Persona, PersonaEntity>());
            var map = configuration.CreateMapper();
            var resultado = map.Map<Persona, PersonaEntity>(personadb);

            return resultado;
        }
    }

}
