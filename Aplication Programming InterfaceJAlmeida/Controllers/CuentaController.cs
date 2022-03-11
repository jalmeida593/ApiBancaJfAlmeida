using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Response;
using Aplication_Programming_InterfaceJAlmeida.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Aplication_Programming_InterfaceJAlmeida.Controllers
{
    /// <summary>
    /// Controlador para Cuentas de Clientes.
    /// </summary>
    [Route("api/cuentas")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly ICuentasService _cuentasService;
        /// <summary>
        /// Constructor Controlador.
        /// </summary>
        public CuentaController(ICuentasService cuentaService)
        {
            _cuentasService = cuentaService;
        }

        /// <summary>
        /// Obtener información sobre las cuentas de un cliente ingresando el número de cédula.
        /// </summary>
        /// <param name="identificacion">Número de identificación de la persona</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CuentasCliente))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<CuentasCliente> GetCuentas(string identificacion)
        {
            return _cuentasService.GetCuentas(identificacion);
        }
        /// <summary>
        /// Inserción de los datos de la cuenta de la persona.
        /// </summary>
        /// <param name="CuentasCliente">Entidad con los datos de la cuenta a crear</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CuentasCliente))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public ActionResult<CuentasCliente> CreatePersona([FromBody] CuentasCliente cuentacreate)
        {
            if (cuentacreate.idCliente > 0)
            {
                try
                {
                    return Ok(_cuentasService.CreateCuenta(cuentacreate));
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
        /// Actualización de los datos de cuenta de la persona.
        /// </summary>
        /// <param name="cuentaupdate">Entidad con los datos de la persona a actualizar:</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CuentasCliente))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public ActionResult<CuentasCliente> UpdatePersona(int Id, [FromBody] CuentasCliente cuentaupdate)
        {
            if (Id > 0)
            {
                try
                {
                    return Ok(_cuentasService.UpdateCuenta(Id, cuentaupdate));
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
        /// Eliminación de los datos de la cuenta de la persona.
        /// </summary>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(status))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public ActionResult<CuentasCliente> DeletePersona(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    return Ok(_cuentasService.DeleteCuenta(Id));
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
