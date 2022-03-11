using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Mappers;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Request;
using Aplication_Programming_InterfaceJAlmeida.Model.Response;
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
            Cliente client = new Cliente();
            PersonaEntity personaEntity = new PersonaEntity();
            if (validaCedula(identificacion))
            {
                try
                {
                    var persona = _bancaDbContext.persona.Where(x => x.identificacion == identificacion).FirstOrDefault();
                    var cliente = _bancaDbContext.cliente.Where(y => y.idPersona == persona.idPersona).FirstOrDefault();
                    if (persona != null)
                    {
                        personaEntity = PersonaMapper.GetPersona(persona);
                        personaEntity.status = new status();
                        personaEntity.status.statuscode = "Ok";
                        personaEntity.status.message = "Extracción Correcta";
                        personaEntity.cliente = cliente;
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

        public PersonaEntity CreatePersonas(PersonaEntity personacreate)
        {
            Persona persona = new Persona();
            Cliente client = new Cliente();
            PersonaEntity personaEntity = new PersonaEntity();


            if (validaCedula(personacreate.identificacion))
            {
                try
                {
                    persona = _bancaDbContext.persona.Where(x => x.identificacion == personacreate.identificacion).FirstOrDefault();
                    if (persona == null)
                    {
                        persona = new Persona();
                        persona.identificacion = personacreate.identificacion;
                        persona.nombre = personacreate.nombre;
                        persona.apellido = personacreate.apellido;
                        persona.genero = personacreate.genero;
                        persona.fechaNacimiento = personacreate.fechaNacimiento;
                        persona.direccion = personacreate.direccion;
                        persona.telefono = personacreate.telefono;
                        _bancaDbContext.Add(persona);
                        _bancaDbContext.SaveChanges();

                        client= _bancaDbContext.cliente.Where(x => x.idPersona == persona.idPersona).FirstOrDefault();
                        client = new Cliente();
                        client.contraseña = personacreate.cliente.contraseña;
                        client.idPersona = persona.idPersona;
                        client.estado = 1;
                        _bancaDbContext.Add(client);
                        _bancaDbContext.SaveChanges();
                        persona = _bancaDbContext.persona.Where(x => x.identificacion == personacreate.identificacion).FirstOrDefault();
                        personaEntity = PersonaMapper.GetPersona(persona);
                        personaEntity.cliente = new Cliente();
                        personaEntity.cliente = _bancaDbContext.cliente.Where(x => x.idPersona == persona.idPersona).FirstOrDefault();
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

        public PersonaEntity UpdatePersonas(int id, PersonaEntity personaupdate)
        {
            Persona persona = new Persona();
            Cliente client = new Cliente();
            PersonaEntity personaEntity = new PersonaEntity();
            try
            {
                persona = _bancaDbContext.persona.Where(x => x.idPersona == id).FirstOrDefault();
                if (persona != null && validaCedula(personaupdate.identificacion))
                {
                    persona.identificacion = personaupdate.identificacion;
                    persona.nombre = personaupdate.nombre;
                    persona.apellido = personaupdate.apellido;
                    persona.genero = personaupdate.genero;
                    persona.fechaNacimiento = personaupdate.fechaNacimiento;
                    persona.direccion = personaupdate.direccion;
                    persona.telefono = personaupdate.telefono;

                    _bancaDbContext.Update(persona);
                    _bancaDbContext.SaveChanges();

                    persona = _bancaDbContext.persona.Where(x => x.idPersona == id).FirstOrDefault();
                    client.contraseña = personaupdate.cliente.contraseña;
                    client.idPersona = persona.idPersona;
                    client.estado = 1;
                    personaEntity = PersonaMapper.GetPersona(persona);
                    _bancaDbContext.Update(client);
                    _bancaDbContext.SaveChanges();
                    personaEntity.status = new status();
                    personaEntity.status.statuscode = "Ok";
                    personaEntity.status.message = "Actualizado Con Exito";
                    personaEntity.cliente = new Cliente();
                    personaEntity.cliente = _bancaDbContext.cliente.Where(x => x.idPersona == persona.idPersona).FirstOrDefault();
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
            var client = _bancaDbContext.cliente.FirstOrDefault(x => x.idPersona == i);
            if (persona != null&& client!=null)
            {
                _bancaDbContext.Remove(client);
                _bancaDbContext.SaveChanges();
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

        public Reporte Getreporte(string cedula)
        {
            throw new NotImplementedException();
        }
    }

}
