using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Request;
using Aplication_Programming_InterfaceJAlmeida.Model.Response;
using Aplication_Programming_InterfaceJAlmeida.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Aplication_Programming_InterfaceJAlmeida.Controllers
{
    /// <summary>
    /// Controlador para Personas.
    /// </summary>
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : Controller
    {
        private readonly IPersonasService _personaService;
        /// <summary>
        /// Constructor Controlador.
        /// </summary>
        public PersonasController(IPersonasService personaService)
        {
            _personaService = personaService;
        }

        /// <summary>
        /// Obtener información sobre la persona ingresada en Db por identificación.
        /// </summary>
        /// <param name="identificacion">Número de identificación de la persona</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaEntityRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public ActionResult<PersonaEntityRequest> GetPersona(string identificacion)
        {
            if (identificacion.Length == 10)
            {
                try
                {
                    return Ok(_personaService.GetPersonas(identificacion));
                }
                catch (SqlException e)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 400,
                        Message = e.Message,
                        Type = e.GetType().Name

                    };
                    return BadRequest(error);
                }
                catch (Exception ex)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 500,
                        Message = ex.Message,
                        Type = ex.GetType().Name

                    };
                    return BadRequest(error);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Inserción de los datos de la persona.
        /// </summary>
        /// <param name="personacreate">Entidad con los datos de la persona a crear</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Persona))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public ActionResult<PersonaEntity> CreatePersona([FromBody] PersonaEntity personacreate)
        {
            if (personacreate.identificacion.Length == 10)
            {
                try
                {
                    return Ok(_personaService.CreatePersonas(personacreate));
                }
                catch (SqlException e)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 400,
                        Message = e.Message,
                        Type = e.GetType().Name

                    };
                    return BadRequest(error);
                }
                catch (Exception ex)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 500,
                        Message = ex.Message,
                        Type = ex.GetType().Name

                    };
                    return BadRequest(error);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Actualización de los datos de la persona.
        /// </summary>
        /// <param name="personacreate">Entidad con los datos de la persona a actualizar:</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public ActionResult<PersonaEntity> UpdatePersona(int Id, [FromBody] PersonaEntity personacreate)
        {
            if (Id > 0)
            {
                try
                {
                    return Ok(_personaService.UpdatePersonas(Id,personacreate));
                }
                catch (SqlException e)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 400,
                        Message = e.Message,
                        Type = e.GetType().Name

                    };
                    return BadRequest(error);
                }
                catch (Exception ex)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 500,
                        Message = ex.Message,
                        Type = ex.GetType().Name

                    };
                    return BadRequest(error);
                }
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Eliminación de los datos de la persona.
        /// </summary>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public ActionResult<status> DeletePersona(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    return Ok(_personaService.DeletePersonas(Id));
                }
                catch (SqlException e)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 400,
                        Message = e.Message,
                        Type = e.GetType().Name

                    };
                    return BadRequest(error);
                }
                catch (Exception ex)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Code = 500,
                        Message = ex.Message,
                        Type = ex.GetType().Name

                    };
                    return BadRequest(error);
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
