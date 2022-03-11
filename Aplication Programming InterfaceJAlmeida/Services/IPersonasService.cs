using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Request;

namespace Aplication_Programming_InterfaceJAlmeida.Services
{
    public interface IPersonasService
    {
        PersonaEntity GetPersonas(string identificacion);
        PersonaEntity CreatePersonas(PersonaEntity persona);
        PersonaEntity UpdatePersonas(int id, PersonaEntity persona);
        status DeletePersonas(int id);
        Reporte Getreporte(string cedula);
    }
}
