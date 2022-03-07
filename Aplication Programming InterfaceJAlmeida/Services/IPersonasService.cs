using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Request;

namespace Aplication_Programming_InterfaceJAlmeida.Services
{
    public interface IPersonasService
    {
        PersonaEntity GetPersonas(string identificacion);
        PersonaEntity CreatePersonas(Persona_cliente persona);
        PersonaEntity UpdatePersonas(int id, Persona_cliente persona);
        status DeletePersonas(int id);
    }
}
