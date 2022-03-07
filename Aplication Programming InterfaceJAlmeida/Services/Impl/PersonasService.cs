using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Mappers;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Request;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aplication_Programming_InterfaceJAlmeida.Services.Impl
{
    public class PersonasService : IPersonasService
    {
        private ILogger<IPersonasService> _logger;
        private readonly BancaDbContext _bancaDbContext;
        private readonly IMapper mapper;
        public IConfiguration _configuration { get; }

        public PersonasService(ILogger<PersonasService> logger, IConfiguration configuration, BancaDbContext bancaDbContext, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _bancaDbContext = bancaDbContext;
            this.mapper = mapper;
        }

        public PersonaEntity GetPersonas(string identificacion)
        {
            Persona_cliente persona = new Persona_cliente();
            PersonaEntity personaEntity = new PersonaEntity();
            if (validaCedula(identificacion))
            {
                try
                {
                    persona = _bancaDbContext.persona.Where(x => x.persona.identificacion == identificacion).FirstOrDefault();
                    if (persona != null)
                    {
                        personaEntity = PersonaMapper.GetPersona(persona);
                        personaEntity.status = new status();
                        personaEntity.status.statuscode = "Ok";
                        personaEntity.status.message = "Extracción Correcta";
                    }
                    else
                    {
                        personaEntity.status = new status();
                        personaEntity.status.statuscode = "Error";
                        personaEntity.status.message = "Persona no Registrada";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error al consultar persona: " + ex);
                }

            }
            return personaEntity;
        }
        bool validaCedula(string cedula)
        {
            int sumOfDigits = 0;
            sumOfDigits = cedula.Where((e) => e >= '0' && e <= '9').Reverse()
                    .Select((e, j) => ((int)e - 48) * (j % 2 == 0 ? 1 : 2))
                    .Sum((e) => e / 10 + e % 10);
            if (sumOfDigits % 10 != 0)
            {
                return false;
            }
            return true;
        }

        public PersonaEntity CreatePersonas(Persona_cliente personacreate)
        {
            Persona_cliente persona = new Persona_cliente();
            PersonaEntity personaEntity = new PersonaEntity();


            if (validaCedula(personacreate.persona.identificacion))
            {
                try
                {
                    persona = _bancaDbContext.persona.Where(x => x.persona.identificacion == personacreate.persona.identificacion).FirstOrDefault();
                    if (persona == null)
                    {
                        _bancaDbContext.Add(personacreate);
                        _bancaDbContext.SaveChanges();
                        persona = _bancaDbContext.persona.Where(x => x.persona.identificacion == personacreate.persona.identificacion).FirstOrDefault();
                        personaEntity = PersonaMapper.GetPersona(persona);
                        personaEntity.status = new status();
                        personaEntity.status.statuscode = "Ok";
                        personaEntity.status.message = "Insertado Con Exito";

                    }
                    else
                    {
                        personaEntity.status = new status();
                        personaEntity.status.statuscode = "Error";
                        personaEntity.status.message = "Persona ya esta Registrada";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error al consultar persona: " + ex);
                }
            }
            return personaEntity;
        }

        public PersonaEntity UpdatePersonas(int id, Persona_cliente personaupdate)
        {
            Persona_cliente persona = new Persona_cliente();
            PersonaEntity personaEntity = new PersonaEntity();

            try
            {

                var persona1 = _bancaDbContext.persona.Where(x => x.idPersona == id).FirstOrDefault();
                if (persona != null && validaCedula(personaupdate.persona.identificacion))
                {
                    _bancaDbContext.Entry(persona).State = EntityState.Detached;
                    persona = mapper.Map(personaupdate, persona1);
                    _bancaDbContext.SaveChanges();
                    personaEntity = PersonaMapper.GetPersona(persona);
                    personaEntity.status = new status();
                    personaEntity.status.statuscode = "Ok";
                    personaEntity.status.message = "Actualizado Con Exito";

                }
                else
                {
                    personaEntity.status = new status();
                    personaEntity.status.statuscode = "Error";
                    personaEntity.status.message = "Persona No esta Registrada!";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al consultar persona: " + ex);
            }
            return personaEntity;
        }

        public status DeletePersonas(int i)
        {
            status status = new status();
            var persona = _bancaDbContext.persona.FirstOrDefault(x => x.idPersona == i);
            if (persona != null)
            {
                _bancaDbContext.Remove(persona);
                _bancaDbContext.SaveChanges();
                status.statuscode = "Ok";
                status.message = "Borrado Con Exito";
            }
            else
            {
                status.statuscode = "Error";
                status.message = "Persona No esta Registrada!";
            }
            return status;  
        }
    }

}
