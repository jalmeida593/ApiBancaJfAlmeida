using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aplication_Programming_InterfaceJAlmeida.Controllers
{
    /// <summary>
    /// Controlador para Cuentas de Clientes.
    /// </summary>
    [Route("cuentas")]
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



    }
}
