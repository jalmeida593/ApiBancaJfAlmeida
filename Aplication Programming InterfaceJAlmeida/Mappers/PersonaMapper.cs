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
        public static PersonaEntity GetPersona(Persona_cliente personadb)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Persona_cliente, PersonaEntity>());
            var map = configuration.CreateMapper();
            var resultado = map.Map<Persona_cliente, PersonaEntity>(personadb);

            return resultado;
        }
    }

}
